using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.FeatureDto;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductAvgByHamburger")]
		public IActionResult ProductAvgByHamburger()
		{
			return Ok(_productService.TProductAvgByHamburger());
		}

		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductCountByMaxPrice")]
		public IActionResult ProductCountByMaxPrice()
		{
			return Ok(_productService.TProductCountByMaxPrice());
		}

		[HttpGet("ProductCountByMinPrice")]
		public IActionResult ProductCountByMinPrice()
		{
			return Ok(_productService.TProductCountByMinPrice());
		}

		[HttpGet("ProductByAvgPrice")]
		public IActionResult ProductByAvgPrice()
		{
			return Ok(_productService.TProductByAvgPrice());
		}


		[HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value=_mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetLast9ProductsWithCategories")]
        public IActionResult GetLast9ProductsWithCategories()
        {
            var value =_productService.TGetLast9ProductsWithCategories();
          return Ok(_mapper.Map<List<ResultProductWithCategory>>(value));
        }
    }
}
