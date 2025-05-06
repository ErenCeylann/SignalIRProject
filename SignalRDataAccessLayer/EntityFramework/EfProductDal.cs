using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;


namespace SignalRDataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).ToList();

			return values;
		}

		public decimal ProductAvgByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Select(y => y.ProductPrice).Average();
		}

		public decimal ProductByAvgPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.ProductPrice);
		}

        public decimal ProductByTotalSaladPrice()
        {
            using var context = new SignalRContext();
			return context.Products.Where(x => x.Category.CategoryName == "Salata").Select(y => y.ProductPrice).Sum();
        }

        public decimal ProductBySteakBurgerPrice()
        {
            using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.ProductPrice).FirstOrDefault();
        }

        public int ProductCount()
		{
			using var context = new SignalRContext();
			return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public string ProductCountByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.OrderByDescending(x => x.ProductPrice).Select(y => y.ProductName).FirstOrDefault();
		}

		public string ProductCountByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice==(context.Products.Min(y=>y.ProductPrice))).Select(y => y.ProductName).FirstOrDefault();
		}

        public decimal ProductTotalByDrinkPrice()
        {
            using var context = new SignalRContext();
			return context.Products.Where(x=>x.Category.CategoryName=="İçecek").Select(y => y.ProductPrice).Sum();
        }

        public decimal ProductTotalPrice()
        {
            using var context = new SignalRContext();
			return context.Products.Sum(x => x.ProductPrice);
        }

        public List<Product> GetLast9ProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Take(9).OrderByDescending(x=>x.ProductId).ToList();

            return values;
        }
    }
}
