using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural.Facade
{
    public interface IInvoiceService
    {
        void GenerateInvoice(Invoice invoice);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly ICalculationService calculationService;
        private readonly IFileService fileService;
        public InvoiceService(ICalculationService calculationService, IFileService fileService)
        {
            this.calculationService = calculationService;
            this.fileService = fileService;
        }

        public void GenerateInvoice(Invoice invoice)
        {
            calculationService.CalculateInvoice(invoice);
            fileService.GenerateResultFile(invoice);
        }
    }

    public interface IFileService
    {
        void GenerateResultFile(Invoice invoice);
    }

    public interface ICalculationService
    {
        void CalculateInvoice(Invoice invoice);
    }

    public class ExcelFileService : IFileService
    {
        private const string ExcelExtension = ".xlsx";

        public void GenerateResultFile(Invoice invoice)
        {
            invoice.FilePath = invoice.TotalAmount.ToString() + ExcelExtension;
        }
    }

    public class CalculationService : ICalculationService
    {
        public void CalculateInvoice(Invoice invoice)
        {
            invoice.CalculateTotalAmount();
        }
    }
}
