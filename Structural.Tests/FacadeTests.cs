using NUnit.Framework;
using Structural.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Structural.Tests
{
    public class FacadeTests
    {
        [Test]
        public void ShouldSetPathToTotalAmount()
        {
            InvoiceService invoiceService = new InvoiceService(new CalculationService(), new ExcelFileService());

            var invoice = new Invoice();

            invoice.AddLine(new InvoiceLine { Formula = "Energy", UnitPrice = 1, Volume = 2 });
            invoice.AddLine(new InvoiceLine { Formula = "Distribution", UnitPrice = 2, Volume = 3 });
            invoice.AddLine(new InvoiceLine { Formula = "Metering", UnitPrice = 1, Volume = 4 });

            invoiceService.GenerateInvoice(invoice);

            Assert.AreEqual("12.xlsx", invoice.FilePath);

        }
    }
}
