using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Headers
{
    class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            headers.Add(header.Key, header);
        }
        public bool ContainsHeader(string key)
        {
            return headers.ContainsKey(key);
        }
        public HttpHeader GetHeader(string key)
        {

            if (headers.ContainsKey(key))
            {
                return headers[key];
            }
            return null;
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, headers.Select(h => string.Join("=", h.Key, h.Value)));
        }
    }
}
