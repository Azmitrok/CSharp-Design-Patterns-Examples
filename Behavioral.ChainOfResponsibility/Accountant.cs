using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class Accountant : IApprover
    {
        const decimal MaxInvoiceAmount = 1000;
        public IApprover NextApprover { get; set; }
        public void Approve(IDocument document)
        {
            if (CanApprove(document))
                document.IsApproved = true;
            else
                NextApprover.Approve(document);
        }

        public bool CanApprove(IDocument document)
        {
            return document is Invoice invoice && invoice.TotalAmount < MaxInvoiceAmount;
        }
    }
}
