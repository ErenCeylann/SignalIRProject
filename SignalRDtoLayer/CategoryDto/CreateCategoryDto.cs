﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.CategoryDto
{
    public class CreateCategoryDto
    {
       
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
