using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;

namespace InvoiceSystemAPI.Services.Abstracts
{
    public interface IInvoiceService
    {
        Task CreateInvoice(Invoice invoice);
        Task<List<Invoice>> GetAllInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<bool> UpdateInvoiceAsync(Invoice updatedInvoice);
        Task DeleteInvoiceAsync(int id);
    }
}
