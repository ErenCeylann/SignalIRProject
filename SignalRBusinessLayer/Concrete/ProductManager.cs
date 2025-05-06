using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetLast9ProductsWithCategories()
        {
            return _productDal.GetLast9ProductsWithCategories();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

		public decimal TProductAvgByHamburger()
		{
			return _productDal.ProductAvgByHamburger();
		}

		public decimal TProductByAvgPrice()
		{
			return _productDal.ProductByAvgPrice();
		}

        public decimal TProductBySteakBurgerPrice()
        {
           return _productDal.ProductBySteakBurgerPrice();
        }

        public decimal TProductByTotalSaladPrice()
        {
            return _productDal.ProductByTotalSaladPrice();
        }

        public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public string TProductCountByMaxPrice()
		{
			return _productDal.ProductCountByMaxPrice();
		}

		public string TProductCountByMinPrice()
		{
			return _productDal.ProductCountByMinPrice();
		}

        public decimal TProductTotalByDrinkPrice()
        {
            return _productDal.ProductTotalByDrinkPrice();
        }

        public decimal TProductTotalPrice()
        {
           return _productDal.ProductTotalPrice();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
