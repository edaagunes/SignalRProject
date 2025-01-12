using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class MenuController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MenuController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v = id;

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7191/api/Product/ProductListWithCategory");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddBasket(int id, int menuTableId)
		{
			if (menuTableId == 0)
			{
				return Json(new { success = false, message = "MenuTableId geçersiz." });
			}
			CreateBasketDto createBasketDto = new CreateBasketDto()
			{
				ProductId = id,
				MenuTableId = menuTableId
			};

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBasketDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7191/api/Basket", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return Json(new { success = true, message = "Ürün başarıyla sepete eklendi." });
			}

			return Json(new { success = false, message = "Bir hata oluştu, lütfen tekrar deneyin." });
		}
	}
}

