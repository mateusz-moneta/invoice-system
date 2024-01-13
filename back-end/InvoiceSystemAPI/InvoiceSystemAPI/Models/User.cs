namespace InvoiceSystemAPI.Models
{
    public class User : BaseEntity
    {
        public enum UserRole
        {
            Admin,
            User
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string? Role { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? TaxNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
