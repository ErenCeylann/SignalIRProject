﻿using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }
    }
}
