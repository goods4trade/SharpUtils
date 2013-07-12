using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MAXX.Utils
{
    public static partial class Extensions
    {
        public static List<T> JsonToList<T>(this string json)
        {
            var list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }

        public static T JsonToItem<T>(this string json)
        {
            var item = JsonConvert.DeserializeObject<T>(json);
            return item;
        }

        public static BaseObjects.RESTfuls.RESTfuls<T> ToRESTful<T>(this List<T> list)
        {
            BaseObjects.RESTfuls.RESTfuls<T> rest = new BaseObjects.RESTfuls.RESTfuls<T>();
            rest.Href = HttpContext.Current.Request.Url.AbsoluteUri;
            rest.Length = list.Count;
            rest.Items = list;

            return rest;
        }

        public static BaseObjects.RESTfuls.RESTful<T> ToRESTful<T>(this T o)
        {
            BaseObjects.RESTfuls.RESTful<T> rest = new BaseObjects.RESTfuls.RESTful<T>();
            rest.Href = HttpContext.Current.Request.Url.AbsoluteUri;
            rest.Length = 1;
            rest.Items = o;

            return rest;
        }

        public static string ToCammelCaseRESTfulString<T>(this List<T> list)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(list, Formatting.Indented, jsonSerializerSettings);
            return json;
        }

        public static string ToCammelCaseRESTfulString<T>(this T o)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var json = JsonConvert.SerializeObject(o, Formatting.Indented, jsonSerializerSettings);
            return json;
        }

        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
    }
}
