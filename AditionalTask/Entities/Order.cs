using System.Collections.Generic;

namespace AditionalTask.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}
