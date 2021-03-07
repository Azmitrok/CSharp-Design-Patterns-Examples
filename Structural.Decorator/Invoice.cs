using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural.Decorator
{
    public class Invoice : IInvoice
    {
        internal List<InvoiceLine> InvoiceLines { get; set; }
        public Invoice()
        {            
            InvoiceLines = new List<InvoiceLine>();
        }        

        public void AddLine(InvoiceLine line)
        {
            InvoiceLines.Add(line);
        }

        public decimal CalculateTotalAmount()
        {
            return InvoiceLines.Sum(l => l.UnitPrice * l.Volume);
        }
    }
}
