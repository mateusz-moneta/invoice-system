using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.PdfGenerator;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using QuestPDF.Fluent;
using System.Net.Http.Headers;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/invoices")]
    [Authorize]

    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly List<Invoice> _invoices = new List<Invoice>();
        private readonly string _pdfPath = "./MediaFiles/Invoices/";

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            try
            {
                var invoices = _invoiceService.GetAllInvoicesAsync().Result;

                if(invoices != null)
                {
                    return Ok(invoices);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("pdf/{invoiceId}")]
        public IActionResult GetInvoicePdf(int invoiceId) 
        {
            var invoice = _invoiceService.GetInvoiceByIdAsync(invoiceId).Result;
            string filePath = GeneratePDF(invoice);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);
            var contentDisposition = new Microsoft.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            Response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();

            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (IOException ex)
            {
                throw new Exception($"Error occurred while deleting the file: {ex.Message}");
            }

            return File(bytes, "application/pdf", fileName);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            try
            {
                var invoice = _invoiceService.GetInvoiceByIdAsync(id).Result;

                if(invoice != null)
                {
                    return Ok(invoice);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Invoice> CreateInvoice(Invoice invoice)
        {
            try
            {
                _invoiceService.CreateInvoiceAsync(invoice);
                return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInvoice(int id, Invoice updatedInvoice)
        {
            try
            {
                var existingInvoice = _invoiceService.GetInvoiceByIdAsync(id).Result;
                if(existingInvoice == null) 
                {
                    return NotFound();
                }

                updatedInvoice.Id = id;

                bool isSuccess = _invoiceService.UpdateInvoiceAsync(updatedInvoice).Result;

                if (isSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInvoice(int id)
        {
            try
            {
                var existingInvoice = _invoiceService.GetInvoiceByIdAsync(id).Result;

                if(existingInvoice == null)
                {
                    return NotFound();
                }

                _invoiceService.DeleteInvoiceAsync(id);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        private string GeneratePDF(Invoice invoice)
        {
            //invoice.Products = _productsService.GetProductsByInvoiceIdAsync(invoice.Id);
            var model = InvoiceDocumentDataSource.GetInvoiceDetails(invoice);
            var document = new InvoiceDocument(model);
            string invoicePath = _pdfPath + $"{invoice.Invoice_Id}_{invoice.Issuer_Name.Replace(' ', '_')}.pdf";
            document.GeneratePdf(invoicePath);
            return invoicePath;
        }

    }
}
