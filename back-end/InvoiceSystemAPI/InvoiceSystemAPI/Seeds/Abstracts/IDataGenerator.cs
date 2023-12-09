using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;

namespace InvoiceSystemAPI.Seeds.Abstracts
{
    public interface IDataGenerator
    {
        Task SeedAsync();
    }
}
