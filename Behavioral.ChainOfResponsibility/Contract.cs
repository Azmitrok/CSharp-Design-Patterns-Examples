using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.ChainOfResponsibility
{
    public class Contract : IDocument
    {
        public bool IsApproved { get; set; }

        public TimeSpan Duration { get; set; }
        public decimal MonthlyPayment { get; set; }
    }
}
