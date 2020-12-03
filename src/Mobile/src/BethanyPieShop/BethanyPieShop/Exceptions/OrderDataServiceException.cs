using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class OrderDataServiceException : Exception
    {
        public OrderDataServiceException()
        {
        }

        public OrderDataServiceException(string message) : base(message)
        {
        }

        public OrderDataServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderDataServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
