﻿namespace AditionalTask.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
