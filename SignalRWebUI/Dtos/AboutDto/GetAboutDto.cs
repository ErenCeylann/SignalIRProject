﻿using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.AboutDto
{
    public class GetAboutDto
    {
        [Key]
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
