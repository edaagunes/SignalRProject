using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.TGetAll();
			return Ok(_mapper.Map<List<ResultAboutDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto createAboutDto)
		{
			var value=_mapper.Map<About>(createAboutDto);
			_aboutService.TAdd(value);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var value = _aboutService.TGetById(id);
			_aboutService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var value = _mapper.Map<About>(updateAboutDto);
			_aboutService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var value=_aboutService.TGetById(id);
			return Ok(_mapper.Map<GetAboutDto>(value));
		}
	}
}
