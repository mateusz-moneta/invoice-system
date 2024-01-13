using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;

namespace InvoiceSystemAPI.Services.Abstracts
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(Invoice invoice, int userId);
        Task<List<Invoice>> GetAllInvoicesAsync(int userId);
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<bool> UpdateInvoiceAsync(Invoice updatedInvoice);
        Task DeleteInvoiceAsync(int id);
    }
}
