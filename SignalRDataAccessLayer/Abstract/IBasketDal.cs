using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;
//using SignalRWebUI.Dtos.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        List<ResultBasketListWithProduct> GetBasketListByMenuTableWithProductName(int id);
    }
}
