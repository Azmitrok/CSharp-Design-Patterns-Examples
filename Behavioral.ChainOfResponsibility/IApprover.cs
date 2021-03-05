using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public interface IApprover
    {
        IApprover NextApprover { get; set; }
        void Approve(IDocument document);

        bool CanApprove(IDocument document);
    }
}
