﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.AboutDto
{
    public class UpdateAboutDto
    {
        [Key]
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
