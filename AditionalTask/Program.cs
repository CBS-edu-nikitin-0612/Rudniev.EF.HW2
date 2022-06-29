using AditionalTask.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ModelEF>());

            using(ModelEF db = new ModelEF())
            {
                Product p1 = new Product { Title = "Potato", Price = 30 };
                Product p2 = new Product { Title = "Tomato", Price = 40 };
                Product p3 = new Product { Title = "Cabbage", Price = 45 };
                Product p4 = new Product { Title = "Cheese", Price = 105 };
                
                db.Products.AddRange(new List<Product> { p1, p2, p3, p4 });
                db.SaveChanges();

                Order o1 = new Order { CustomerName = "Vlad", Products = new List<Product> { p1, p4 } };
                Order o2 = new Order { CustomerName = "Grisha", Products = new List<Product> { p2, p3 } };

                db.Orders.AddRange(new List<Order> { o1, o2 });
                db.SaveChanges();
            }

            using(ModelEF db = new ModelEF())
            {
                var products = db.Products.ToList();

                System.Console.WriteLine("Products:");
                foreach (var item in products)
                {
                    System.Console.WriteLine("{0} - {1} (Customer: {2})", item.Title, item.Price, item.Order != null ? item.Order.CustomerName : "Not customer");
                }
                System.Console.WriteLine(new string('-', 50));

                var orders = db.Orders.ToList();

                System.Console.WriteLine("Orders:");
                foreach (var order in orders)
                {
                    System.Console.WriteLine($"Customer - {order.CustomerName}");

                    if (order.Products == null) continue;

                    foreach (var product in order.Products)
                    {
                        System.Console.WriteLine($"{product.Title} - {product.Price}");
                    }
                }
            }
            System.Console.ReadKey();
        }
    }
}
