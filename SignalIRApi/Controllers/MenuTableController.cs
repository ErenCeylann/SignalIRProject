using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MenuTableDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTableController(IMenuTableService menuTableService,IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}
        [HttpGet("List")]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
        }
        [HttpGet]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}
		
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.Status = false;
			var value = _mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.TAdd(value);
			return Ok("Masa Kısmı Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.TGetById(id);
			_menuTableService.TDelete(values);
			return Ok("Başarılı Bir Şekilde Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var value=_mapper.Map<MenuTable>(updateMenuTableDto);
			updateMenuTableDto.Status = false;
			_menuTableService.TUpdate(value);
			return Ok("Masa Alanı Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(_mapper.Map<ResultMenuTableDto>(value));
		}

		[HttpGet("ChangeMenuTableStatusFalse")]
		public IActionResult ChangeMenuTableStatusFalse(int id)
		{
			_menuTableService.TChangeMenuTableStatusFalse(id);
			return Ok("İşlem başarılı");
		}

        [HttpGet("ChangeMenuTableStatusTrue")]
        public IActionResult ChangeMenuTableStatusTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusTrue(id);
            return Ok("İşlem başarılı");
        }
    }
}
