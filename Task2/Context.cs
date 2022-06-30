using Microsoft.EntityFrameworkCore;
using Task2.Entities;

namespace Task2
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2GR07E0\\SQLEXPRESS;Database=EF_HW2_Task2;Trusted_Connection=True;");
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
