//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;
//using SignalRWebUI.Dtos.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<ResultBasketListWithProduct> GetBasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.MenuTableId == id).Include(y => y.Product).Select(z => new ResultBasketListWithProduct
            {
                BasketId = z.BasketId,
                Count = z.Count,
                MenuTableId = z.MenuTableId,
                ProductId = z.ProductId,
                TotalPrice = z.TotalPrice,
                Price = z.Price,
                ProductName = z.Product.ProductName

            }).ToList();
            return values;
        }
    }
}
