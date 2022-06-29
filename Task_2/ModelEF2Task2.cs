using System;
using System.Data.Entity;
using System.Linq;
using Task_2.Entities;

namespace Task_2
{
    public class ModelEF2Task2 : DbContext
    {
        public ModelEF2Task2() : base("name=ModelEF2Task2") { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}