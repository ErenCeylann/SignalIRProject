﻿using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> Baskets { get; set; }

    }
}
