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
            if (!routeValueDictionary.ContainsKey(propertyName))
                throw new Exception(string.Format("مشخصه {0}  در لیست ارسالی وجود ندارد", propertyName));

            var value = routeValueDictionary[propertyName];

            if (value == null)
                return default(T);

            // ------------------------------------------------------------
            // FAST PATH (exception-free): the value's actual runtime type
            // already matches T exactly - this is by far the most common
            // case, and needs no conversion at all.
            //
            // The original code instead did "try { return (T)value; }
            // catch { }" - a hard, unboxing cast attempt. That only
            // succeeds when the boxed type is EXACTLY T; a boxed `long`
            // being cast to `int` (or any other close-but-not-exact numeric
            // mismatch) throws InvalidCastException every single time
            // instead of just failing this fast check and moving on to a
            // real conversion below. Thrown-and-caught exceptions are
            // nearly free with no debugger attached, but extremely slow
            // (tens to hundreds of ms each) with one attached - which,
            // multiplied across every GetValue<T> call on every field of
            // every record on a busy screen, is what produced the
            // mysterious "only slow while debugging" behavior seen
            // throughout this app.
            // ------------------------------------------------------------
            if (value is T)
                return (T)value;

            Type targetType = typeof(T);
            Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (underlyingType == typeof(string))
            {
                string s = Publics.FixCharacters(Convert.ToString(value));
                return (T)(object)s;
            }

            // Handles the common numeric/bool/DateTime widening & narrowing
            // conversions (long<->int, decimal<->long, etc.) directly and
            // WITHOUT throwing for the normal case - this covers the
            // overwhelming majority of what used to hit the exception path
            // above.
            if (value is IConvertible)
            {
                try
                {
                    return (T)Convert.ChangeType(value, underlyingType, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (InvalidCastException) { /* fall through to Parse below */ }
                catch (FormatException) { /* fall through to Parse below */ }
            }

            // Last-resort fallback, unchanged from the original, for types
            // Convert.ChangeType doesn't handle (enums, custom types with a
            // static Parse method) - reached far less often now.
            string stringValue = Convert.ToString(value);
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                var methodInfo = underlyingType.GetMethod("Parse", new Type[] { typeof(string) });
                if (methodInfo != null)
                    return (T)methodInfo.Invoke(null, new object[] { stringValue });
            }

            return default(T);
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
