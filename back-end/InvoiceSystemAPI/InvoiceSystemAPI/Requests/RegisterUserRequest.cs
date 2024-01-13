using System.ComponentModel.DataAnnotations;

namespace InvoiceSystemAPI.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
