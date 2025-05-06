using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();

        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();

        string ProductCountByMaxPrice();
        string ProductCountByMinPrice();

        decimal ProductByAvgPrice();

        decimal ProductAvgByHamburger();

        decimal ProductBySteakBurgerPrice();

        decimal ProductTotalByDrinkPrice();

        decimal ProductByTotalSaladPrice();

        decimal ProductTotalPrice();

        List<Product> GetLast9ProductsWithCategories();

        
    }
}
