using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class NotificationMapping:Profile
	{
		public NotificationMapping()
		{
			CreateMap<About, ResultNotificationDto>().ReverseMap();
			CreateMap<About, CreateNotificationDto>().ReverseMap();
			CreateMap<About, UpdateNotificationDto>().ReverseMap();
			CreateMap<About, GetByIdNotificationDto>().ReverseMap();
		}
	}
}
