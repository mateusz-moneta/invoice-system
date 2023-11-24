using System.ComponentModel.DataAnnotations;

namespace InvoiceSystemAPI.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}