using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Task_2.Entities;
using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ModelEF2Task2>());
            using (ModelEF2Task2 db = new ModelEF2Task2())
            {
                Product p1 = new Product { Title = "Potato", Price = 30 };
                Product p2 = new Product { Title = "Tomato", Price = 40 };
                Product p3 = new Product { Title = "Cabbage", Price = 45 };
                Product p4 = new Product { Title = "Cheese", Price = 105 };
                db.Products.AddRange(new List<Product> { p1, p2, p3, p4 });
                db.SaveChanges();

                Customer c1 = new Customer { Name = "Vlad", LastName = "Rudniev", phoneNumber = "380995675656" };
                Customer c2 = new Customer { Name = "Grisha", LastName = "Pupkin", phoneNumber = "380981232354" };
                db.Customers.AddRange(new List<Customer> { c1, c2 });
                db.SaveChanges();

                Order o1 = new Order { Customer = c1, Products = new List<Product> { p1, p4 } };
                Order o2 = new Order { Customer = c2, Products = new List<Product> { p2, p3 } };
                Order o3 = new Order { Customer = c1, Products = new List<Product> { p1, p2, p3 } };


                db.Orders.AddRange(new List<Order> { o1, o2, o3 });
                db.SaveChanges();

                var orders = db.Orders.ToList();

                Console.WriteLine("Orders:");
                Console.WriteLine(new string('-', 50));
                foreach (var order in orders)
                {
                    Console.WriteLine("Customer - {0} {1}", order.Customer != null ? order.Customer.Name : "No", order.Customer != null ? order.Customer.LastName : "customer");
                    Console.WriteLine("Order id - {0}", order.Id);
                    if (order.Products == null)
                    {
                        Console.WriteLine("Products empty");
                    }
                    else
                    {
                        Console.WriteLine("Products:");
                        var products = order.Products.ToList();
                        foreach (var product in products)
                        {
                            Console.WriteLine("{0} - {1}", product.Title, product.Price);
                        }
                    }
                    Console.WriteLine(new string('-', 50));
                }
                Console.ReadKey();
            }
        }
    }
}
