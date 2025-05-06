using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;
//using SignalRWebUI.Dtos.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
       public List<ResultBasketListWithProduct> TGetBasketListByMenuTableWithProductName(int id);
    }
}
