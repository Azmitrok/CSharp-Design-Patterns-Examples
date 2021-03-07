using System;
using System.Collections.Generic;
using System.Text;

namespace Structural.Decorator
{
    public class CreditNoteInvoiceDecorator : IInvoiceDecorator
    {
        private readonly IInvoice invoice;

        public CreditNoteInvoiceDecorator(IInvoice invoice)
        {
            this.invoice = invoice;
        }
        public decimal CalculateTotalAmount()
        {
            return -1 * invoice.CalculateTotalAmount();
        }
    }
}
