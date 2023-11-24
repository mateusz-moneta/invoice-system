namespace InvoiceSystemAPI.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }
    }
}
