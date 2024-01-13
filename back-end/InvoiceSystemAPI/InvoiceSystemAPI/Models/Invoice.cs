using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystemAPI.Models
{
    public class Invoice : BaseEntity
    {
        public string Invoice_Id { get; set; }
        public DateTime Invoice_Date { get; set; }
        public DateTime Transaction_Date { get; set; }
        public DateTime Payment_Date { get; set; } //DueDate
        public string Note { get; set; }
        public string IssuerVATCode { get; set; }
        public string Issuer_Name { get; set; }
        public string Issuer_Address { get; set; }
        public string Issuer_City { get; set; }
        public string Issuer_Zip { get; set; }
        public string BuyerVATCode { get; set; }
        public string Buyer_Name { get; set; }
        public string Buyer_Address { get; set; }
        public string Buyer_City { get; set; }   
        public string Buyer_Zip { get; set; }
        public bool Is_Paid { get; set; }
        public int Status_Id { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
