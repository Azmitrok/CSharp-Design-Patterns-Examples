using System;
using System.Collections.Generic;
using System.Text;

namespace Structural.Decorator
{
    public class VatInvoiceDecorator : IInvoiceDecorator
    {
        private readonly IInvoice invoice;
        private readonly decimal vatInPercent;

        public VatInvoiceDecorator(IInvoice invoice, decimal vatInPercent)
        {
            this.invoice = invoice;
            this.vatInPercent = vatInPercent;
        }
        public decimal CalculateTotalAmount()
        {
            return invoice.CalculateTotalAmount() * (1 + vatInPercent / 100);
        }
    }
}
