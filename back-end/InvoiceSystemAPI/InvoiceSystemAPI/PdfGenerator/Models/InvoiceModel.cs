using InvoiceSystemAPI.Models;
using System.Net;

namespace InvoiceSystemAPI.PdfGenerator.Models
{
    public class InvoiceModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public PartyData SellerData { get; set; }
        public PartyData CustomerData { get; set; } // musze dodac NIP

        public List<Product> Products { get; set; } = new List<Product>();
        public string Comments { get; set; }
        public bool IsPaid { get; set; }
        public string ImagePath { get; set; }
    }
}
