using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceSystemAPI.Services
{
    public class InvoiceService: IInvoiceService
    {
        private readonly DataContext _applicationDbContext;

        public InvoiceService(DataContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task CreateInvoiceAsync(Invoice invoice)
        {
            try
            {  
                _applicationDbContext.Invoices.Add(invoice);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Invoice create error");
            }
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _applicationDbContext.Invoices.Include(i => i.Products).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _applicationDbContext.Invoices
                .Include(i => i.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateInvoiceAsync(Invoice updatedInvoice)
        {
            var existingInvoice = await _applicationDbContext.Invoices
                .Include(i => i.Products)
                .FirstOrDefaultAsync(x => x.Id == updatedInvoice.Id);

            if (existingInvoice != null)
            {

                try
                {
                    existingInvoice.Invoice_Date = updatedInvoice.Invoice_Date;
                    existingInvoice.Transaction_Date = updatedInvoice.Transaction_Date;
                    existingInvoice.Payment_Date = updatedInvoice.Payment_Date;
                    existingInvoice.Note = updatedInvoice.Note;
                    existingInvoice.IssuerVATCode = updatedInvoice.IssuerVATCode;
                    existingInvoice.Issuer_Name = updatedInvoice.Issuer_Name;
                    existingInvoice.Issuer_Address = updatedInvoice.Issuer_Address;
                    existingInvoice.Issuer_City = updatedInvoice.Issuer_City;
                    existingInvoice.Issuer_Zip = updatedInvoice.Issuer_Zip;
                    existingInvoice.Buyer_Name = updatedInvoice.Buyer_Name;
                    existingInvoice.BuyerVATCode = updatedInvoice.BuyerVATCode;
                    existingInvoice.Buyer_Address = updatedInvoice.Buyer_Address;
                    existingInvoice.Buyer_City = updatedInvoice.Buyer_City;
                    existingInvoice.Buyer_Zip = updatedInvoice.Buyer_Zip;
                    existingInvoice.Is_Paid = updatedInvoice.Is_Paid;
                    existingInvoice.Status_Id = updatedInvoice.Status_Id;
                    existingInvoice.Products = updatedInvoice.Products;

                    _applicationDbContext.Invoices.Update(existingInvoice);
                    await _applicationDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw new Exception("Invoice update error");
                }
       
                return true;
            }

            return false;
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoiceToDelete = await _applicationDbContext.Invoices.FirstOrDefaultAsync(x => x.Id == id);

            if (invoiceToDelete != null) 
            {
                try
                {
                    _applicationDbContext.Invoices.Remove(invoiceToDelete);
                await _applicationDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Invoice deletion error");
                }
            }
        }
    }
}