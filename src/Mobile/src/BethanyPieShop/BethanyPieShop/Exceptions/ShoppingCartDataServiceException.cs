using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class ShoppingCartDataServiceException : Exception
    {
        public ShoppingCartDataServiceException()
        {
        }

        public ShoppingCartDataServiceException(string message) : base(message)
        {
        }

        public ShoppingCartDataServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShoppingCartDataServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
