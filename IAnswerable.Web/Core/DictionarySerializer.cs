///Copyright IAnswerable 2012 - 2013
///http://www.IAnswerable.com
namespace IAnswerable.Web.Core
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Specialized;
    using System;

    /// <summary>
    /// Convert Dictionary to Storgly typed class
    /// </summary>
    /// <typeparam name="T">Class type</typeparam>
    public class DictionaryConverter<T> where T : class, new()
    {
        public T ToDictionary(Dictionary<string, string> value)
        {
            T t = new T();

            PropertyInfo[] _properties = t.GetType().GetProperties();

            string key;

            foreach (var _property in _properties)
            {
                var keyattribute = _property.GetCustomAttributes(true).OfType<Key>().FirstOrDefault();

                if (keyattribute != null)
                {
                    key = keyattribute.Name;
                }
                else
                {
                    key = _property.Name;
                }


                if (keyattribute.IsIgnoreCase)
                {
                    if (value.Keys.Contains(key, StringComparer.InvariantCultureIgnoreCase))
                    {
                        key = value.Keys.Where(item => item.Equals(key, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                        _property.SetValue(t, value[key], null);
                    }
                }
                else
                {
                    if (value.ContainsKey(key))
                    {
                        _property.SetValue(t, value[key], null);
                    }
                }
                
            }

            return t;
        }

        public Dictionary<string, string> ToObject(T t)
        {
            PropertyInfo[] _properties = t.GetType().GetProperties();

            Dictionary<string, string> converteddictionary = new Dictionary<string, string>(_properties.Count());

   
            string key;

            for (int counter = 0; counter < _properties.Length; counter++)
            {
                var keyattribute = _properties[counter].GetCustomAttributes(true).OfType<Key>().FirstOrDefault();

                if (keyattribute != null)
                {
                    key = keyattribute.Name;
                }
                else
                {
                    key = _properties[counter].Name;
                }

                var value = _properties[counter].GetValue(t, null);

                if (keyattribute.IsIgnoreOnNull)
                {
                    if (value != null)
                    {
                        converteddictionary.Add(key, (string)value);
                    }
                }
                else
                {
                    converteddictionary.Add(key, (string)value);
                }
            }

            return converteddictionary;
        }
    }
}
