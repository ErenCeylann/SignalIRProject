using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value) ;
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            updateDiscountDto.Status = false;
            var value=_mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("ChangToStatusFalse/{id}")]
        public IActionResult ChangToStatusFalse(int id)
        {
            _discountService.TChangToStatusFalse(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ChangToStatusTrue/{id}")]
        public IActionResult ChangToStatusTrue(int id)
        {
            _discountService.TChangToStatusTrue(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {   
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
