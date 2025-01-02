using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByFalse());
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification();
			{
				notification.Type = createNotificationDto.Type;
				notification.Icon = createNotificationDto.Icon;
				notification.Description = createNotificationDto.Description;
				notification.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
				notification.Status = false;
			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification();
			{
				notification.NotificationId = updateNotificationDto.NotificationId;
				notification.Type = updateNotificationDto.Type;
				notification.Icon = updateNotificationDto.Icon;
				notification.Description = updateNotificationDto.Description;
				notification.Date = updateNotificationDto.Date;
				notification.Status = updateNotificationDto.Status;
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			return Ok(_notificationService.TGetById(id));
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}

	}
}
