using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace IAnswerable.Web.Core
{
    public class NameValueCollectionSerializer<T> where T : class, new()
    {
        DictionarySerializer<T> _dictionaryserializer = new DictionarySerializer<T>();

        public T Deserialize(NameValueCollection value)
        {
            var dictionary = value.ToDictionary();

            return _dictionaryserializer.Deserialize(dictionary);
        }
    }



}
