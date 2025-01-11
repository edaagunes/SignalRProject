using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.Status = false;
			createMessageDto.MessageSendDate = DateTime.Now;

			var value = _mapper.Map<Message>(createMessageDto);
			_messageService.TAdd(value);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			updateMessageDto.Status = false;
			var value = _mapper.Map<Message>(updateMessageDto);
			_messageService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value= _messageService.TGetById(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(value));
		}
	}
}
