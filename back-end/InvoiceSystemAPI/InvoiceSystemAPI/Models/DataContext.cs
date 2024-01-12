using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace InvoiceSystemAPI.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
