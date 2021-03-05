using System;
using System.Runtime.Serialization;

namespace Behavioral.ChainOfResponsibility
{
    [Serializable]
    internal class ApprovalException : Exception
    {
        public ApprovalException()
        {
        }

        public ApprovalException(string message) : base(message)
        {
        }

        public ApprovalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApprovalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}