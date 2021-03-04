using Behavioral.State;
using NUnit.Framework;

namespace Behavioral.Tests
{
    public class StateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FunctionalTest()
        {
            var invoice = new Invoice();

            invoice.AddLine(new InvoiceLine { Formula = "Energy", UnitPrice = 1, Volume = 2 });
            invoice.AddLine(new InvoiceLine { Formula = "Distribution", UnitPrice = 2, Volume = 3 });
            invoice.AddLine(new InvoiceLine { Formula = "Metering", UnitPrice = 1, Volume = 3 });

            var draftException = Assert.Throws<InvoiceStateException>(() => invoice.CalculateTotalAmount());
            Assert.IsTrue(draftException.Message.Contains("draft", System.StringComparison.OrdinalIgnoreCase));

            invoice.ChangeState(new GeneratedState());

            Assert.AreEqual(11, invoice.CalculateTotalAmount());

            invoice.ChangeState(new CreditNoteState());

            Assert.AreEqual(-11, invoice.CalculateTotalAmount());

            invoice.ChangeState(new ErrorState());

            var errorException = Assert.Throws<InvoiceStateException>(() => invoice.CalculateTotalAmount());

            Assert.IsTrue(errorException.Message.Contains("error", System.StringComparison.OrdinalIgnoreCase));
        }
    }
}