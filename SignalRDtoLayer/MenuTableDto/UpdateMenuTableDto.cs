﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.MenuTableDto
{
	public class UpdateMenuTableDto
	{
		public int MenuTableId { get; set; }
		public string MenuTableName { get; set; }

		public bool Status { get; set; }
	}
}
