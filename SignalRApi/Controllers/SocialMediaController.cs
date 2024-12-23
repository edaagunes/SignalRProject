using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;

		public SocialMediaController(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}
		[HttpGet]
		public IActionResult SocialMediaList()
		{
			return Ok(_socialMediaService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			SocialMedia socialMedia = new SocialMedia()
			{
				Title = createSocialMediaDto.Title,
				Icon = createSocialMediaDto.Icon,
				Url = createSocialMediaDto.Url,
			};
			_socialMediaService.TAdd(socialMedia);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteSocialMedia(int id)
		{
			var value = _socialMediaService.TGetById(id);
			_socialMediaService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			SocialMedia socialMedia = new SocialMedia()
			{
				SocialMediaId = updateSocialMediaDto.SocialMediaId,
				Title = updateSocialMediaDto.Title,
				Icon = updateSocialMediaDto.Icon,
				Url = updateSocialMediaDto.Url,
			};
			_socialMediaService.TUpdate(socialMedia);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetSocialMedia")]
		public IActionResult GetSocialMedia(int id)
		{
			return Ok(_socialMediaService.TGetById(id));
		}
	}
}
