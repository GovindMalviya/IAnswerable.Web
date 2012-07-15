using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IAnswerable.Web.Core;

namespace IAnswerable.Web.WebPage
{
    public class Page<T> : System.Web.UI.Page where T : class, new()
    {
        private T _querystringmodel;

        public T QueryStringModel
        {
            get
            {
                if (_querystringmodel == null)
                {
                    NameValueCollectionSerializer<T> _dictionaryserializer = new NameValueCollectionSerializer<T>();
                    _querystringmodel = _dictionaryserializer.Deserialize(Request.QueryString);
                }

                return _querystringmodel;
            }
        }

        public string GetQueryString()
        {
            KeyValueStringDeserializer<T> _keyvalueserializer = new KeyValueStringDeserializer<T>();
            return _keyvalueserializer.Serialize(_querystringmodel);
        }
    }
}
