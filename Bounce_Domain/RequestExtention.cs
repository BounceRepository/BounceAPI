using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain
{

    public class requestModel
    {
        public object Type { get; set; }
        public PropertyInfo [] Properties { get; set; }
    }
    public static class RequestExtention
    {
        public static requestModel load()
        {
            var assemb = Assembly.GetExecutingAssembly();
            var types = assemb.DefinedTypes.ToList();
            var requestType = types.FirstOrDefault();

          

            var type = types.FirstOrDefault(x => x.Name == "Chat");
            var act = Type.GetType(requestType.FullName);

            var scssc = act.GetType().GetProperty("SenderId");
            var objectType = Activator.CreateInstance(act);

            var properties = act.GetProperties(); 

            foreach (var prop in properties)
            {
                var value = "";
            }

            return  new requestModel { Type = objectType , Properties = requestType.GetProperties()} ;

        }


      
    }


}
