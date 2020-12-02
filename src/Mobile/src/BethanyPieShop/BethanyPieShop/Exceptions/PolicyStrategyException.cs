using System;
using System.Runtime.Serialization;

namespace BethanyPieShop.Core.Exceptions
{
    public class PolicyStrategyException : Exception
    {
        public PolicyStrategyException()
        {
        }

        public PolicyStrategyException(string message) : base(message)
        {
        }

        public PolicyStrategyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PolicyStrategyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
