using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IAnswerable.Web.Core;

namespace IAnswerable.Web.WebPage
{
    public static class RequestExtensions
    {
        /// <summary>
        /// Get QueryString as strongly typed object.
        /// </summary>
        /// <typeparam name="T">Storngly typed class</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static T GetQueryString<T>(this HttpRequest request) where T : class, new()
        {
            NameValueCollectionSerializer<T> _dictionaryserializer = new NameValueCollectionSerializer<T>();
            return _dictionaryserializer.Deserialize(request.QueryString);
        }

        /// <summary>
        /// Create Key Value String from object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CreateKeyValueString(this object obj)
        {
            KeyValueStringDeserializer<object> _keyvalueserializer = new KeyValueStringDeserializer<object>();
            return _keyvalueserializer.Serialize(obj);
        }
    }
}
