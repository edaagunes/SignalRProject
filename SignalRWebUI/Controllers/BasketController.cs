using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.CouponDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class BasketController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BasketController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
		{
			TempData["tableId"] = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7191/api/Basket/BasketListByMenuTableWithProductName?id=" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);


				return View(values);
			}
			return View();
		}
		public async Task<IActionResult> DeleteBasket(int id)
		{
			int tableId = int.Parse(TempData["tableId"].ToString());
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7191/api/Basket/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new { id = tableId });
			}
			return NoContent();
		}

		public async Task<IActionResult> CompleteOrder(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7191/api/Basket/DeleteByMenuTable/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var client2 = _httpClientFactory.CreateClient();
				await client2.GetAsync("https://localhost:7191/api/MenuTables/ChangeMenuTableStatusToFalse?id=" + id);


				return RedirectToAction("CustomerTableList", "CustomerTable");
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ApplyCoupon([FromBody] CouponDto couponDto,int id)
		{
			if (string.IsNullOrEmpty(couponDto.CouponCode))
			{
				return Json(new { success = false, message = "Kupon kodu boş olamaz." });
			}

			// Kupon koduna göre indirim oranı belirle
			decimal discount = 0;
			if (couponDto.CouponCode == "INDIRIM10")
			{
				discount = 10; // %10 indirim
			}
			else if (couponDto.CouponCode == "INDIRIM20")
			{
				discount = 20; // %20 indirim
			}
			else
			{
				return Json(new { success = false, message = "Geçersiz kupon kodu." });
			}

			// Sepet toplamını API'den çek
			var client = _httpClientFactory.CreateClient();
			//int menuTableId = int.Parse(TempData["tableId"].ToString());
			var responseMessage = await client.GetAsync($"https://localhost:7191/api/Basket/TotalPriceBasketByMenuTableId/{id}");

			if (!responseMessage.IsSuccessStatusCode)
			{
				return Json(new { success = false, message = "Sepet toplamı alınamadı." });
			}

			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			decimal basketTotalPrice = JsonConvert.DeserializeObject<decimal>(jsonData);

			// İndirim uygulanmış fiyat
			decimal basketTotalPriceWithDiscount = basketTotalPrice - (basketTotalPrice * discount / 100);
			decimal tax = (basketTotalPriceWithDiscount / 100) * 10;
			decimal basketTotalPriceWithTax = basketTotalPriceWithDiscount + tax;

			return Json(new
			{
				success = true,
				discount = discount,
				totalPrice = basketTotalPriceWithDiscount,
				tax = tax,
				totalPriceWithTax = basketTotalPriceWithTax
			});
		}


	}
}
