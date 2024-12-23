using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			return Ok(_featureService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
		{
			Feature feature = new Feature()
			{
				Title = createFeatureDto.Title,
				Description = createFeatureDto.Description,
			};
			_featureService.TAdd(feature);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteFeature(int id)
		{
			var value = _featureService.TGetById(id);
			_featureService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			Feature feature = new Feature()
			{
				FeatureId = updateFeatureDto.FeatureId,
				Title = updateFeatureDto.Title,
				Description = updateFeatureDto.Description,
			};
			_featureService.TUpdate(feature);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetFeature")]
		public IActionResult GetFeature(int id)
		{
			return Ok(_featureService.TGetById(id));
		}
	}
}
