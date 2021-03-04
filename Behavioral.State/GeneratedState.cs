using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behavioral.State
{
    public class GeneratedState : IState
    {
        public decimal CalculateTotalAmount(Invoice invoice)
        {
            return invoice.invoiceLines.Sum(l => l.UnitPrice * l.Volume);
        }
    }
}
