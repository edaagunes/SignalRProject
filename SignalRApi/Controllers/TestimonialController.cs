using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			return Ok(_testimonialService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			Testimonial testimonial = new Testimonial()
			{
				Title = createTestimonialDto.Title,
				ImageUrl = createTestimonialDto.ImageUrl,
				Comment = createTestimonialDto.Comment,
				Name = createTestimonialDto.Name,
				Status = createTestimonialDto.Status,
			};
			_testimonialService.TAdd(testimonial);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetById(id);
			_testimonialService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			Testimonial testimonial = new Testimonial()
			{
				TestimonialId = updateTestimonialDto.TestimonialId,
				Title = updateTestimonialDto.Title,
				ImageUrl = updateTestimonialDto.ImageUrl,
				Comment = updateTestimonialDto.Comment,
				Name = updateTestimonialDto.Name,
				Status = updateTestimonialDto.Status,
			};
			_testimonialService.TUpdate(testimonial);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetTestimonial")]
		public IActionResult GetTestimonial(int id)
		{
			return Ok(_testimonialService.TGetById(id));
		}
	}
}
