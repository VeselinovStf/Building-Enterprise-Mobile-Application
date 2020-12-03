using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class CatalogDataServiceException : Exception
    {
        public CatalogDataServiceException()
        {
        }

        public CatalogDataServiceException(string message) : base(message)
        {
        }

        public CatalogDataServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CatalogDataServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
