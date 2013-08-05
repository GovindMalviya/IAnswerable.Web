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
        DictionaryConverter<T> _dictionaryconverter = new DictionaryConverter<T>();

        public T Deserialize(string keyValueString)
        {
            var _dictionary = keyValueString.Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);

            T t = _dictionaryconverter.ToDictionary(_dictionary);

            return t;
        }

        public string Serialize(T t)
        {
            var dictionaryresult = _dictionaryconverter.ToObject(t);

            return string.Join("&", dictionaryresult.Select(x => { return string.Format("{0}={1}", x.Key, x.Value); }));
        }
    }
}
