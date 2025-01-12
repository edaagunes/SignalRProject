using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
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
	}
}
