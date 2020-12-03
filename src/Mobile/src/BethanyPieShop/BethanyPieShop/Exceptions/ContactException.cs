using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class ContactException : Exception
    {
        public ContactException()
        {
        }

        public ContactException(string message) : base(message)
        {
        }

        public ContactException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
