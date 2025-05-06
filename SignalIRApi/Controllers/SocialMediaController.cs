using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDtoLayer.ProductDto;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISoicialMediaService _soicialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISoicialMediaService soicialMediaService, IMapper mapper)
        {
            _soicialMediaService = soicialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_soicialMediaService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _soicialMediaService.TAdd(value);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _soicialMediaService.TGetById(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value=_mapper.Map<SocialMedia>(updateSocialMediaDto);   
            _soicialMediaService.TUpdate(value);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _soicialMediaService.TGetById(id);
            _soicialMediaService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}
