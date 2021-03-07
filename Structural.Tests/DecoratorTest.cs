using NUnit.Framework;
using Structural.Decorator;

namespace Structural.Tests
{
    public class Tests
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
            invoice.AddLine(new InvoiceLine { Formula = "Metering", UnitPrice = 1, Volume = 4 });

            Assert.AreEqual(12, invoice.CalculateTotalAmount());

            Assert.AreEqual(-12, new CreditNoteInvoiceDecorator(invoice).CalculateTotalAmount());

            Assert.AreEqual(18, new VatInvoiceDecorator(invoice, 50).CalculateTotalAmount());

            Assert.AreEqual(-18, new CreditNoteInvoiceDecorator(new VatInvoiceDecorator(invoice, 50)).CalculateTotalAmount());
        }
    }
}