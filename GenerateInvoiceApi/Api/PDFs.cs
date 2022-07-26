﻿using DinkToPdf;
using DinkToPdf.Contracts;
using GenerateInvoiceApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GenerateInvoiceApi.Api
{
    [Route("api/pdfcreator")]
    [ApiController]
    public class PDFs : Controller
    {

        private IConverter _converter;
        public PDFs(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                // Out = @"C:\Users\Ildeberto\Desktop\Employee_Report.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PDFGenerator.getHTML(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Urbanist", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Urbanist", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file=_converter.Convert(pdf);
            return File(file, "application/pdf");
        }
    }
}
