using System.Collections.Generic;

namespace Task_2.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? phoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
