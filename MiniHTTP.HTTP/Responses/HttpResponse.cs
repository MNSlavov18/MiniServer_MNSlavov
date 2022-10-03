
using MiniHTTP.HTTP.Common;
using MiniHTTP.HTTP.Enums;
using MiniHTTP.HTTP.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.HTTP.Responses
{
    class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }
        public HttpResponse(HttpResponseStatusCode statusCode) : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }
        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; set; }


        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] getBytes()
        {
            return Encoding.ASCII.GetBytes(ToString() + Content);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment}{(int)this.StatusCode}{this.StatusCode.ToString()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);

            result.Append(GlobalConstants.HttpNewLine);
            return result.ToString();

        }
    }
}
