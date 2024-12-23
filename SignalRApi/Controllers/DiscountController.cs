using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;

		public DiscountController(IDiscountService discountService)
		{
			_discountService = discountService;
		}
		[HttpGet]
		public IActionResult DiscountList()
		{
			return Ok(_discountService.TGetAll());
		}

		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			Discount discount = new Discount()
			{
				Amount = createDiscountDto.Amount,
				Description	= createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl,
				Title = createDiscountDto.Title,
			};
			_discountService.TAdd(discount);
			return Ok("Ekleme Başarılı");
		}
		[HttpDelete]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			_discountService.TDelete(value);
			return Ok("Silme Başarılı");
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			Discount discount = new Discount()
			{
				DiscountId = updateDiscountDto.DiscountId,
				Amount = updateDiscountDto.Amount,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl,
				Title = updateDiscountDto.Title,
			};
			_discountService.TUpdate(discount);
			return Ok("Güncelleme Başarılı");
		}
		[HttpGet("GetDiscount")]
		public IActionResult GetDiscount(int id)
		{
			return Ok(_discountService.TGetById(id));
		}
	}
}
