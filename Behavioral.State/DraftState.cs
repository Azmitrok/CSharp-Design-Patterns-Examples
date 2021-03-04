using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Behavioral.State
{
    public class DraftState : IState
    {
        public decimal CalculateTotalAmount(Invoice invoice)
        {
            throw new InvoiceStateException("Total amount can't be calculated for Draft Invoice state");
        }
    }
}
