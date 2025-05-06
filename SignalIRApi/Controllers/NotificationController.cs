using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService,IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetNotificationList()
        {
            var value = _notificationService.TGetAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(value));
        }
        [HttpGet("Sayi")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Date = DateTime.Now;
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(_mapper.Map<ResultNotificationDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            updateNotificationDto.Date = DateTime.Now;  
            var value=_mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("NotificationStatusChangToTrue/{id}")]
        public IActionResult NotificationStatusChangToTrue(int id)
        {
            _notificationService.TNotificationChangToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }

		[HttpGet("NotificationStatusChangToFalse/{id}")]
		public IActionResult NotificationStatusChangToFalse(int id)
		{
			_notificationService.TNotificationChangToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}

	}
}
