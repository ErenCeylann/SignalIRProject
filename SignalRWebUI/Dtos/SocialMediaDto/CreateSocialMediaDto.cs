﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.SocialMediaDto
{
    public class CreateSocialMediaDto
    {
        
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
