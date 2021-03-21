using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural.Facade
{
    public class Invoice
    {
        internal List<InvoiceLine> InvoiceLines { get; set; }
        public decimal TotalAmount { get; private set; }
        public string FilePath { get; set; }

        public Invoice()
        {
            InvoiceLines = new List<InvoiceLine>();
        }

        public void AddLine(InvoiceLine line)
        {
            InvoiceLines.Add(line);
        }

        public void CalculateTotalAmount()
        {
            TotalAmount = InvoiceLines.Sum(l => l.UnitPrice * l.Volume);
        }


    }

    public class InvoiceLine
    {
        public string Formula { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Volume { get; set; }
    }
}
