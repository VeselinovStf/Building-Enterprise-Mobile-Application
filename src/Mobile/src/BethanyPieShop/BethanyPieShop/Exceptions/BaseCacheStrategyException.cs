using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class BaseCacheStrategyException : Exception
    {
        public BaseCacheStrategyException()
        {
        }

        public BaseCacheStrategyException(string message) : base(message)
        {
        }

        public BaseCacheStrategyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseCacheStrategyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
