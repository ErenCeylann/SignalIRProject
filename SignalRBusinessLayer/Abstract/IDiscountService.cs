﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangToStatusFalse(int id);
        void TChangToStatusTrue(int id);

        List<Discount> TGetListByStatusTrue();
    }
}
