﻿using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
