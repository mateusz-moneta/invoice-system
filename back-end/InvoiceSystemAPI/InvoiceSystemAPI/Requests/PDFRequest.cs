using System.ComponentModel.DataAnnotations;

namespace InvoiceSystemAPI.Requests
{
    public class PDFRequest
    {
        [Required]
        public int InvoiceID { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
