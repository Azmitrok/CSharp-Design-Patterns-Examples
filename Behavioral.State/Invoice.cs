using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.State
{
    public class Invoice
    {
        private IState state;
        internal List<InvoiceLine> invoiceLines { get; set; }
        public Invoice()
        {
            state = new DraftState();
            invoiceLines = new List<InvoiceLine>();
        }        

        public void AddLine(InvoiceLine line)
        {
            invoiceLines.Add(line);
        }

        public decimal CalculateTotalAmount()
        {
            return state.CalculateTotalAmount(this);
        }

        public void ChangeState(IState state)
        {
            this.state = state;
        }
    }
}
