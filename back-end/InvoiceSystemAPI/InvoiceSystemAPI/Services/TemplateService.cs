using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystemAPI.Services;


public class TemplateService : ITemplateService
{
    private readonly DataContext _context;

    public TemplateService(DataContext context)
    {
        _context = context;
    }

    public async Task<Template> GetTemplateByIdAsync(int id)
    {
        return await _context.Templates.FindAsync(id);    }

    public async Task<List<Template>> GetAllTemplatesAsync()
    {
        return await _context.Templates.ToListAsync();
    }

    public async Task CreateTemplate(Template template)
    {
        await _context.Templates.AddAsync(template);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateTemplateAsync(Template updatedTemplate)
    {
        var existingTemplate = await _context.Templates.FindAsync(updatedTemplate.Id);
        if (existingTemplate != null)
        {
            _context.Entry(existingTemplate).CurrentValues.SetValues(updatedTemplate);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task DeleteTemplateAsync(int id)
    {
        var template = await _context.Templates.FindAsync(id);
        if (template != null)
        {
            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();
        }
    }
}