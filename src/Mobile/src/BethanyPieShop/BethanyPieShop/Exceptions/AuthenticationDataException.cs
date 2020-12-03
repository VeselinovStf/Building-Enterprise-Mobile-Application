using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class AuthenticationDataException : Exception
    {
        public AuthenticationDataException()
        {
        }

        public AuthenticationDataException(string message) : base(message)
        {
        }

        public AuthenticationDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
