///Copyright IAnswerable 2012 - 2013
///http://www.IAnswerable.com
namespace IAnswerable.Web.Core
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// Convert Dictionary to Storgly typed class
    /// </summary>
    /// <typeparam name="T">Class type</typeparam>
    public class DictionarySerializer<T> where T : class, new()
    {
        public T Deserialize(Dictionary<string, string> value)
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

                if (value.ContainsKey(key))
                {
                    _property.SetValue(t, value[key], null);
                }
            }

            return t;
        }
    }
}
