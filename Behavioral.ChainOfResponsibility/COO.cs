using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class COO : IApprover
    {
        //TODO: implement via settings 
        const decimal MaxMonthlyPayment = 1000;
        public IApprover NextApprover { get; set; }
                
        public void Approve(IDocument document)
        {
            if (CanApprove(document))
            {
                document.IsApproved = true;
                SendNotificationToCEO();
            }
            else
                NextApprover.Approve(document);
        }

        private void SendNotificationToCEO()
        {
            //throw new NotImplementedException();
        }

        public bool CanApprove(IDocument document)
        {
            return document is Contract contract && contract.Duration.TotalDays < 365 && contract.MonthlyPayment < MaxMonthlyPayment;
        }
    }
}
