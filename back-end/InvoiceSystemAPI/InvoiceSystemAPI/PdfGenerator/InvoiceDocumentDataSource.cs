using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.PdfGenerator.Models;

namespace InvoiceSystemAPI.PdfGenerator
{
    public static class InvoiceDocumentDataSource
    {
        public static InvoiceModel GetInvoiceDetails(Invoice invoice)
        {

            return new InvoiceModel
            {
                InvoiceNumber = invoice.Invoice_Id,
                IssueDate = invoice.Invoice_Date,
                DueDate = invoice.Payment_Date,

                SellerData = new PartyData
                {
                    CompanyName = invoice.Issuer_Name,
                    Street = invoice.Issuer_Address,
                    City = invoice.Issuer_City,
                    Zip = invoice.Issuer_Zip,
                    VATCode = invoice.IssuerVATCode
                },
                CustomerData = new PartyData
                {
                    CompanyName = invoice.Buyer_Name,
                    Street = invoice.Buyer_Address,
                    City = invoice.Buyer_City,
                    Zip = invoice.Buyer_Zip,
                    VATCode = invoice.BuyerVATCode
                },

                Products = invoice.Products.ToList(),
                Comments = invoice.Note
            };
        }
    }
}
