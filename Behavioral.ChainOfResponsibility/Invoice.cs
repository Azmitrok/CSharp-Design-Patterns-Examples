using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class Invoice : IDocument
    {
        public bool IsApproved { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
