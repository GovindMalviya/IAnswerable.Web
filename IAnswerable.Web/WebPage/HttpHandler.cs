using System;
using System.Web;
using IAnswerable.Web.Core;

namespace IAnswerable.Web.WebPage
{
    public abstract class HttpHandler<T> : IHttpHandler where T : class, new()
    {
        private T _querystringmodel;

        public T QueryStringModel
        {
            get
            {
                if (_querystringmodel == null)
                {
                    NameValueCollectionSerializer<T> _dictionaryserializer = new NameValueCollectionSerializer<T>();
                    _querystringmodel = _dictionaryserializer.Deserialize(HttpContext.Current.Request.QueryString);
                }

                return _querystringmodel;
            }
        }

        public string GetQueryString()
        {
            KeyValueStringDeserializer<T> _keyvalueserializer = new KeyValueStringDeserializer<T>();
            return _keyvalueserializer.Serialize(_querystringmodel);
        }


        public abstract bool IsReusable
        {
            get;
        }

        public abstract void ProcessRequest(HttpContext context);
    }
}
