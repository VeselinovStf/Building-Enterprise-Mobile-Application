using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class ContactDataException : Exception
    {
        public ContactDataException()
        {
        }

        public ContactDataException(string message) : base(message)
        {
        }

        public ContactDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContactDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
