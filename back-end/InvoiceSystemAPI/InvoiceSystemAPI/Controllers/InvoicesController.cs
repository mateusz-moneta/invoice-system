using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.PdfGenerator;
using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using QuestPDF.Fluent;
using System.Net.Http.Headers;

namespace InvoiceSystemAPI.Controllers
{
    /// <summary>
    /// Controller responsible for managing invoice operations.
    /// </summary>
    [ApiController]
    [Route("/api/invoices")]
    [Authorize]
    public class InvoicesController : Controller
    {

        private readonly IInvoiceService _invoiceService;
        private readonly IUserService _userService;
        private readonly string _pdfPath = "./MediaFiles/Invoices/";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesController"/> class.
        /// </summary>
        /// <param name="invoiceService">The invoice service.</param>
        public InvoicesController(IInvoiceService invoiceService, IUserService userService)
        {
            _invoiceService = invoiceService;
            _userService = userService;
        }
        /// <summary>
        /// Get all Invoices.
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves all invoices.
        /// </remarks>
        /// <returns>A list of all invoices.</returns>
        [HttpGet("all/{userId}")]
        public async Task<IActionResult> GetAllInvoices(int userId)
        {
            try
            {
                var invoices = _invoiceService.GetAllInvoicesAsync(userId).Result;

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
        /// <summary>
        /// Retrieves a PDF format invoice by its unique identifier.
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>The requested invoice in PDF format.</returns>
        [HttpGet("pdf")]
        public IActionResult GetInvoicePdf([FromBody] PDFRequest pdfRequest) 
        {
            var invoice = _invoiceService.GetInvoiceByIdAsync(pdfRequest.InvoiceID).Result;
            string filePath = GeneratePDF(invoice, pdfRequest.UserId);

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
        /// <summary>
        /// Retrieves an invoice by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice.</param>
        /// <returns>The requested invoice.</returns>
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
        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        /// <param name="invoice">The details of the invoice to be created.</param>
        /// <returns>The created invoice.</returns>
        [HttpPost("{userId}")]

        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice, int userId)
        {
            try
            {
                await _invoiceService.CreateInvoiceAsync(invoice, userId);
                return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice to be updated.</param>
        /// <param name="updatedInvoice">The updated details of the invoice.</param>
        /// <returns>The updated invoice.</returns>
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
        /// <summary>
        /// Deletes an invoice by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice to be deleted.</param>
        /// <returns>No content if successful, NotFound if the invoice is not found.</returns>
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

        private string GeneratePDF(Invoice invoice, int userId)
        {
            User user = _userService.GetUserAsync(userId).Result;

            var model = InvoiceDocumentDataSource.GetInvoiceDetails(invoice, user);
            var document = new InvoiceDocument(model);
            string invoicePath = _pdfPath + $"{invoice.Invoice_Id}_{invoice.Issuer_Name.Replace(' ', '_')}.pdf";
            document.GeneratePdf(invoicePath);
            return invoicePath;
        }

    }
}
