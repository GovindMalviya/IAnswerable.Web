///Copyright IAnswerable 2012 - 2013
///http://www.IAnswerable.com
namespace IAnswerable.Web.Core
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Serialize and Deserialize key value string
    /// </summary>
    /// <typeparam name="T">class type</typeparam>
    public class KeyValueStringDeserializer<T> where T : class, new()
    {
        public T Deserialize(string keyValueString)
        {
            var _dictionary = keyValueString.Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);

            DictionarySerializer<T> _dictionaryserializer =new DictionarySerializer<T>();

            T t = _dictionaryserializer.Deserialize(_dictionary);
            
            return t;
        }

        public string Serialize(T t)
        {
            PropertyInfo[] _properties = t.GetType().GetProperties();
            
            string[] keyvaluepairstring =new string[_properties.Count()];
            string key;

            for (int counter = 0;counter< keyvaluepairstring.Length; counter++)
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

                var value =  _properties[counter].GetValue(t, null);

                if (keyattribute.IsIgnoreOnNull)
                {
                    if (value != null)
                    {
                        keyvaluepairstring[counter] = string.Format("{0}={1}", key, value);
                    }
                }
                else
                {
                    keyvaluepairstring[counter] = string.Format("{0}={1}", key, value);
                }
            }

            return string.Join("&", keyvaluepairstring.Where(x=> !string.IsNullOrEmpty(x)));
        }
    }
}
