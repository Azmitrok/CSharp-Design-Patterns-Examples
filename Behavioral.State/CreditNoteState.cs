using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behavioral.State
{
    public class CreditNoteState : IState
    {
        public decimal CalculateTotalAmount(Invoice invoice)
        {
            return -1 * invoice.invoiceLines.Sum(l => l.UnitPrice * l.Volume);
        }
    }
}
