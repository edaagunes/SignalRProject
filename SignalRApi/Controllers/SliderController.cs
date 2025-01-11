using AutoMapper;
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
		private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var value = _mapper.Map<Slider>(createSliderDto);
			_sliderService.TAdd(value);
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
			var value = _mapper.Map<Slider>(updateSliderDto);
			_sliderService.TUpdate(value);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var value= _sliderService.TGetById(id);
			return Ok(_mapper.Map<GetSliderDto>(value));
		}
	}
}
