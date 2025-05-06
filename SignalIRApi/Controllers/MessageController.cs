using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _MessageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService MessageService, IMapper mapper)
        {
            _MessageService = MessageService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _MessageService.TGetAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.MessageSendDate =Convert.ToDateTime( DateTime.Now.ToShortDateString());
            var value = _mapper.Map<Message>(createMessageDto);
            _MessageService.TAdd(value);
            return Ok("Mesaj Gönderildi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values = _MessageService.TGetById(id);
            _MessageService.TDelete(values);
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            updateMessageDto.MessageSendDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var value=_mapper.Map<Message>(updateMessageDto);
            _MessageService.TUpdate(value);
            return Ok("Mesaj Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _MessageService.TGetById(id);
            return Ok(_mapper.Map<ResultMessageDto>(value));
        }
    }
}
