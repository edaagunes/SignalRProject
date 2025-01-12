using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}
		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.Status = false;
			var value=_mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.TAdd(value);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var value = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}
	}
}
