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
        return await _context.Templates.FindAsync(id);
    }

    public async Task<List<Template>> GetAllTemplatesAsync()
    {
        return await _context.Templates.ToListAsync();
    }

    public async Task CreateTemplateAsync(Template template)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.Templates.AddAsync(template);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<bool> UpdateTemplateAsync(Template updatedTemplate)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var existingTemplate = await _context.Templates.FirstOrDefaultAsync(x => x.Id == updatedTemplate.Id);
                if (existingTemplate != null)
                {
                    _context.Entry(existingTemplate).CurrentValues.SetValues(updatedTemplate);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }

                await transaction.RollbackAsync();
                return false;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task DeleteTemplateAsync(int id)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var template = await _context.Templates.FirstOrDefaultAsync(x => x.Id == id);
                if (template != null)
                {
                    _context.Templates.Remove(template);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    await transaction.RollbackAsync();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}