using System;
using System.Net;

namespace BethanyPieShop.Core.Exceptions
{
    public class HttpRequestExceptionExeption : Exception
    {
        public HttpStatusCode HttpCode { get; }

        public HttpRequestExceptionExeption(HttpStatusCode code) : this(code, null, null)
        {
        }

        public HttpRequestExceptionExeption(HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public HttpRequestExceptionExeption(HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            HttpCode = code;
        }
    }
}
