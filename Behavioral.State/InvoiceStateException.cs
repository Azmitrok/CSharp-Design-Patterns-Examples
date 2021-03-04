using System;
using System.Runtime.Serialization;

namespace Behavioral.State
{
    [Serializable]
    public class InvoiceStateException : Exception
    {
        public InvoiceStateException()
        {
        }

        public InvoiceStateException(string message) : base(message)
        {
        }

        public InvoiceStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvoiceStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}