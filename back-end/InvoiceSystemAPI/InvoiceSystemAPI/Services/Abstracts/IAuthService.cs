using InvoiceSystemAPI.Models;

namespace InvoiceSystemAPI.Services.Abstracts
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(User user, string password);
    }
}
