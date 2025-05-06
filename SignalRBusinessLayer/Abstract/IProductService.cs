using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> TGetProductsWithCategories();
		int TProductCount();
		int TProductCountByCategoryNameDrink();
		int TProductCountByCategoryNameHamburger();

		string TProductCountByMaxPrice();
		string TProductCountByMinPrice();

		public decimal TProductByAvgPrice();

		public decimal TProductAvgByHamburger();

        decimal TProductBySteakBurgerPrice();

        decimal TProductTotalByDrinkPrice();

        decimal TProductByTotalSaladPrice();

		decimal TProductTotalPrice();

		List<Product> TGetLast9ProductsWithCategories();
    }
}
