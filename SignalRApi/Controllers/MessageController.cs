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

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_messageService.TGetAll());
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message();
			{
				message.Mail=createMessageDto.Mail;
				message.Subject=createMessageDto.Subject;
				message.MessageContent=createMessageDto.MessageContent;
				message.MessageSendDate=DateTime.Now;
				message.Status = false;
				message.NameSurname=createMessageDto.NameSurname;
				message.Phone=createMessageDto.Phone;
			};
			_messageService.TAdd(message);
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
			Message message = new Message();
			{
				message.MessageId=updateMessageDto.MessageId;
				message.Mail = updateMessageDto.Mail;
				message.Subject = updateMessageDto.Subject;
				message.MessageContent = updateMessageDto.MessageContent;
				message.MessageSendDate = updateMessageDto.MessageSendDate;
				message.Status = false;
				message.NameSurname = updateMessageDto.NameSurname;
				message.Phone = updateMessageDto.Phone;
			};
			_messageService.TUpdate(message);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			return Ok(_messageService.TGetById(id));
		}
	}
}
