using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class PrincipalAccountant : IApprover
    {
        public IApprover NextApprover { get; set; }
        public void Approve(IDocument document)
        {
            if (CanApprove(document))
            {
                document.IsApproved = true;
                SendNotificationToAccounting();
            }
            else
                NextApprover.Approve(document);
        }

        private void SendNotificationToAccounting()
        {
            //throw new NotImplementedException();
        }

        public bool CanApprove(IDocument document)
        {
            if (document is Invoice)
                return true;

            return false;
        }
    }
}
