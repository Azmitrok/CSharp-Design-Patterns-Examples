using Behavioral.State;
using System;

namespace DesingPatternsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create invoice");

            var invoice = new Invoice();

            invoice.AddLine(new InvoiceLine { Formula="Energy", UnitPrice=33, Volume=350});
            invoice.AddLine(new InvoiceLine { Formula = "Distribution", UnitPrice = 7, Volume = 380 });
            invoice.AddLine(new InvoiceLine { Formula = "Metering", UnitPrice = 3, Volume = 350 });

            decimal total;
            try
            {
                total = invoice.CalculateTotalAmount();
            }
            catch(Exception exc)  
            {
                var s = exc.Message;
            }

            invoice.ChangeState(new GeneratedState());

            total = invoice.CalculateTotalAmount();

            invoice.ChangeState(new CreditNoteState());

            total = invoice.CalculateTotalAmount();

            invoice.ChangeState(new ErrorState());

            try
            {
                total = invoice.CalculateTotalAmount();
            }
            catch (Exception exc)
            {
                var s = exc.Message;
            }

        }
    }
}
