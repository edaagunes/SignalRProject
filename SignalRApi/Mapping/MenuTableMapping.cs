using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class MenuTableMapping:Profile
	{
		public MenuTableMapping()
		{
			CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
			CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
		}
	}
}
