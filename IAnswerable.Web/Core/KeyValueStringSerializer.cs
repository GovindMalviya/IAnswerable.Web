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
    }
}
