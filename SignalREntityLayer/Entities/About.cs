﻿using System.ComponentModel.DataAnnotations;

namespace SignalREntityLayer.Entities
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
