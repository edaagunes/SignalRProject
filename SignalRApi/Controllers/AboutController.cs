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

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			return Ok(_aboutService.TGetAll());
		}
		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto createAboutDto)
		{
			About about = new About();
			{
				about.ImageUrl = createAboutDto.ImageUrl;
				about.Title = createAboutDto.Title;
				about.Description = createAboutDto.Description;
			};
			_aboutService.TAdd(about);
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
			About about = new About();
			{
				about.AboutId = updateAboutDto.AboutId;
				about.ImageUrl = updateAboutDto.ImageUrl;
				about.Title = updateAboutDto.Title;
				about.Description = updateAboutDto.Description;
			};
			_aboutService.TUpdate(about);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetAbout")]
		public IActionResult GetAbout(int id)
		{
			return Ok(_aboutService.TGetById(id));
		}
	}
}
