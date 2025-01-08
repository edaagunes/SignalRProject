using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _sliderService;

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			return Ok(_sliderService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			Slider slider = new Slider()
			{
				Title = createSliderDto.Title,
				Description = createSliderDto.Description,
			};
			_sliderService.TAdd(slider);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteSlider(int id)
		{
			var value = _sliderService.TGetById(id);
			_sliderService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			Slider slider = new Slider()
			{
				SliderId = updateSliderDto.SliderId,
				Title = updateSliderDto.Title,
				Description = updateSliderDto.Description,
			};
			_sliderService.TUpdate(slider);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			return Ok(_sliderService.TGetById(id));
		}
	}
}
