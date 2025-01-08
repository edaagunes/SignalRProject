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
				Description = createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl,
				Title = createDiscountDto.Title,
				Status = false
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
				Status = false
			};
			_discountService.TUpdate(discount);
			return Ok("Güncelleme Başarılı");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			return Ok(_discountService.TGetById(id));
		}

		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif");
		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif");
		}
		[HttpGet("GetListByStatusTrue")]
		public IActionResult GetListByStatusTrue()
		{
			return Ok(_discountService.TGetListByStatusTrue());
		}
	}
}
