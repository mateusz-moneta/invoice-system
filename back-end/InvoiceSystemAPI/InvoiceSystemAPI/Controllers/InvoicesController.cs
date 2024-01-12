using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/invoices")]
    [Authorize]

    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly List<Invoice> _invoices = new List<Invoice>();

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

    }
}
