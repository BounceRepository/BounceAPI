using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class EnumerableExtentions
    {

		/// <summary>
		/// Executes an action over each of the elements in the list/enumeration
		/// </summary>
		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (var item in enumeration)
				action(item);
		}

		/// <summary>
		/// Executes an action over each of the elements in the list/enumeration that macthes the predicate
		/// </summary>
		public static void UpdateItems<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate, Action<T> action)
		{
			enumeration
				.Where(predicate)
				.ForEach(action);
		}

		/// <summary>
		/// Converting an enumeration to an Entity type object.
		/// Because the entity or complex type cannot be constructed in a LINQ to Entities query.
		/// </summary>		
		public static IEnumerable<TEntity> ToEntityType<T, TEntity>(this IEnumerable<T> enumeration, Func<T, TEntity> action)
		{
			// Do not use the ReSharper suggestion. It will throw an exception!
			foreach (var item in enumeration)
				yield return action(item);
		}

		/// <summary>
		/// Inserts an item in the list just before the first matched item by the <param name="predicate">predicate</param>
		/// </summary>
		public static List<T> InsertBefore<T>(this List<T> list, Predicate<T> predicate, T item)
		{
			var index = list.FindIndex(predicate);
			if (index < 0)
				index = 0;

			list.Insert(index, item);
			return list;
		}

		/// <summary>
		/// Inserts items in the list just before the first matched item by the <param name="predicate">predicate</param>
		/// </summary>
		public static List<T> InsertBefore<T>(this List<T> list, Predicate<T> predicate, IEnumerable<T> items)
		{
			var index = list.FindIndex(predicate);
			if (index < 0)
				index = 0;

			list.InsertRange(index, items);
			return list;
		}

		/// <summary>
		/// Inserts an item in the list just after the first matched item by the <param name="predicate">predicate</param>
		/// </summary>
		public static List<T> InsertAfter<T>(this List<T> list, Predicate<T> predicate, T item)
		{
			var index = list.FindIndex(predicate);
			if (index >= 0)
				list.Insert(index + 1, item);
			else
				list.Add(item);

			return list;
		}

		/// <summary>
		/// Inserts items in the list just after the first matched item by the <param name="predicate">predicate</param>
		/// </summary>
		public static List<T> InsertAfter<T>(this List<T> list, Predicate<T> predicate, IEnumerable<T> items)
		{
			var index = list.FindIndex(predicate);
			if (index >= 0)
				list.InsertRange(index + 1, items);
			else
				list.AddRange(items);

			return list;
		}


		public static IEnumerable<T> DependencySort<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle = false)
		{
			var sorted = new List<T>();
			var visited = new HashSet<T>();

			foreach (var item in source)
				Visit(item, visited, sorted, dependencies, throwOnCycle);

			return sorted;
		}

		private static void Visit<T>(T item, HashSet<T> visited, List<T> sorted, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle)
		{
			if (!visited.Contains(item))
			{
				visited.Add(item);

				foreach (var dep in dependencies(item))
					Visit(dep, visited, sorted, dependencies, throwOnCycle);

				sorted.Add(item);
			}
			else
			{
				if (throwOnCycle && !sorted.Contains(item))
					throw new Exception("Cyclic dependency found");
			}
		}



		/// <summary>
		/// Filtering and removing of dublicate records based on property name selector.
		/// Because distinting by property value can not be constructed in a LINQ to Entities query.
		/// </summary>	


		public static IEnumerable<TEntity> DistinctByProperty<TEntity, TKey>(this IEnumerable<TEntity> enumeration, Expression<Func<TEntity, TKey>> keySelector)
		{

			if (enumeration == null || enumeration.Count() < 1)
				return enumeration;

			MemberExpression member_expression = (MemberExpression)keySelector.Body;

			//Getting the peroperty name from the selector
			var property_name = member_expression.Member.Name;

			//Initializing an empty list of TEntity
			var queryFilter = new List<TEntity>();

			foreach (var item in enumeration)
			{
				//getting the property value of keyselector
				var proValue = item?.GetType().GetProperty(property_name)?.GetValue(item);

				//Cheking if the item exists in queryFilter container, if yes then no need to add twice
				bool determinant = queryFilter.Any(x => x.GetType().GetProperty(property_name)?.GetValue(x)?.ToString() == proValue?.ToString());

				if (!determinant)
				{
					queryFilter.Add(item);
				}
			}

			return queryFilter;


		}

	}
}
