using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Context
{
	public interface IRepository<TEntity> where TEntity : class
	{
        IQueryable<TEntity> Table { get; }
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(object id);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
