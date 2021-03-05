using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class CEO : IApprover
    {
        public IApprover NextApprover { get => null; set => throw new ApprovalException("CEO is the final approver"); }
        

        public void Approve(IDocument document)
        {
            if (CanApprove(document))
            {
                document.IsApproved = true;
                SendNotificationToCorporate();
            }
            else
                throw new ApprovalException("CEO can't approve a document");
        }

        private void SendNotificationToCorporate()
        {
            //throw new NotImplementedException();
        }

        public bool CanApprove(IDocument document)
        {
            return true;
        }
    }
}
