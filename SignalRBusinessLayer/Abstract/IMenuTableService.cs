﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
	public interface IMenuTableService:IGenericService<MenuTable>
	{
		int TMenuTableCount();

        void TChangeMenuTableStatusTrue(int id);
        void TChangeMenuTableStatusFalse(int id);
    }
}
