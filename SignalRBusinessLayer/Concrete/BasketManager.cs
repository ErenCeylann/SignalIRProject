using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;
//using SignalRWebUI.Dtos.BasketDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
          throw new NotImplementedException();
        }

        public List<ResultBasketListWithProduct> TGetBasketListByMenuTableWithProductName(int id)
        {
            return _basketDal.GetBasketListByMenuTableWithProductName(id);
        }

        public Basket TGetById(int id)
        {
           return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }

        List<ResultBasketListWithProduct> IBasketService.TGetBasketListByMenuTableWithProductName(int id)
        {
            return _basketDal.GetBasketListByMenuTableWithProductName(id);
        }
    }
}
