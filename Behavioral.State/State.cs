using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.State
{
    public interface IState
    {
        decimal CalculateTotalAmount(Invoice invoice);
    }
}
