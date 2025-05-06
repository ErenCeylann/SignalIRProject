using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketListByMenuTableWithProductName(int id)
        {
            var values=_basketService.TGetBasketListByMenuTableWithProductName(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            
            using var context=new SignalRContext();
            
                _basketService.TAdd(new Basket()
                {
                    ProductId = createBasketDto.ProductId,
                    Count = 1,
                    MenuTableId = createBasketDto.MenuTableId,
                    Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId).Select(y => y.ProductPrice).FirstOrDefault(),
                    TotalPrice = 0
                });
                return Ok();
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var values=_basketService.TGetById(id);
            _basketService.TDelete(values);
            return Ok("Sepetten ürün silindi");
        }
    }
}
