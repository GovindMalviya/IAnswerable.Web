using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace IAnswerable.Web.Core
{
    public class NameValueCollectionSerializer<T> where T : class, new()
    {
        DictionaryConverter<T> _dictionaryconverter = new DictionaryConverter<T>();

        public T Deserialize(NameValueCollection value)
        {
            var dictionary = value.ToDictionary();

            return _dictionaryconverter.ToDictionary(dictionary);
        }
    }



}
