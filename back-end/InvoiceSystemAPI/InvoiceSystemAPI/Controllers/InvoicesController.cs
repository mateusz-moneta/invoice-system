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
            return Ok(this._invoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _invoices.Find(x => x.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost]
        public ActionResult<Invoice> CreateInvoice(Invoice invoice)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInvoice(int id, Invoice updatedInvoice)
        {
            var index = _invoices.FindIndex(i => i.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInvoice(int id)
        {
            var index = _invoices.FindIndex(i=>i.Id == id);
            if(index == -1)
            {
                return NotFound();
            }

            _invoices.RemoveAt(index);
            return NoContent();
        }

    }
}
