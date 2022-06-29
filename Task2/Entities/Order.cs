using System.Collections.Generic;

namespace Task2.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}
