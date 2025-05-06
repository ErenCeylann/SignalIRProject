using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.DiscountDto;
using SignalRDtoLayer.SliderDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _SliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _SliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_SliderService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto  createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _SliderService.TAdd(value);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _SliderService.TGetById(id);
            return Ok(_mapper.Map<ResultSliderDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            _SliderService.TUpdate(value);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _SliderService.TGetById(id);
            _SliderService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}
