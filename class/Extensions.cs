
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dentistry
{
    public static class Extensions
    {        
        public static T GetValue<T>(this System.Web.Routing.RouteValueDictionary routeValueDictionary, string propertyName)
        {
            if (routeValueDictionary.ContainsKey(propertyName))
            {
                var value = routeValueDictionary[propertyName];
                
                try { return (T)value; }
                catch { }
                string stringValue = Convert.ToString(value);
                if (typeof(T) == typeof(string))
                {
                    stringValue =  Publics.FixCharacters(stringValue);
                    return (T)(object)stringValue;
                }
                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    var methodInfo = typeof(T).GetMethod("Parse", new Type[] { typeof(string) });
                    T retValue = (T)methodInfo.Invoke(typeof(T), new object[] { stringValue });
                    return retValue;
                }
                return default(T);
            }
            else
            {
                throw new Exception(string.Format("مشخصه {0}  در لیست ارسالی وجود ندارد", propertyName));
            }
        }
              
        public static bool HasValue(this System.Web.Routing.RouteValueDictionary routeValueDictionary, string propertyName)
        {
            if (routeValueDictionary.ContainsKey(propertyName))
            {
                var value = routeValueDictionary[propertyName];
                if (value == null)
                    return false;
                if (value.ToString() == "null")
                    return false;

                string stringValue = Convert.ToString(value);
                return !string.IsNullOrEmpty(stringValue);
            }
            return false;
        }


        public static dynamic GetDynamicObject(this System.Web.Routing.RouteValueDictionary routeValueDictionary)
        {
            dynamic requestDetailObject = new System.Dynamic.ExpandoObject();
            foreach (var item in routeValueDictionary)
                (requestDetailObject as System.Collections.Generic.IDictionary<string, object>).Add(item.Key, item.Value);
            return requestDetailObject;
        }

        public static string Filter(this string str, List<char> charsToRemove)
        {
            charsToRemove.ForEach(c => str = str.Replace(c.ToString(), String.Empty));
            return str;
        }
    }


   
}




