using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
	public class _MenuCategoryFilterComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> Invoke()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7191/api/Categpry");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
