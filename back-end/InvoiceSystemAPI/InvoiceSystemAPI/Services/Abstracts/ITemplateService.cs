using InvoiceSystemAPI.Models;

namespace InvoiceSystemAPI.Services.Abstracts;

public interface ITemplateService
{
    Task<Template> GetTemplateByIdAsync(int id);
    Task<List<Template>> GetAllTemplatesAsync();
    Task CreateTemplate(Template template);
    Task<bool> UpdateTemplateAsync(Template updatedTemplate);
    Task DeleteTemplateAsync(int id);
}