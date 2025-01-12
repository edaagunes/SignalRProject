using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Dtos.ValidationErrorsDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class BookATableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookATableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("https://localhost:7191/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
		{


			HttpClient client2 = new HttpClient();
			HttpResponseMessage response = await client2.GetAsync("https://localhost:7191/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;

			createBookingDto.Description = "abc";

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBookingDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7191/api/Booking", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			else
			{
				ModelState.Clear();
				var errorContent = await responseMessage.Content.ReadAsStringAsync();
				List<ResultValidationErrorDto>? validationErrors = JsonConvert.DeserializeObject<List<ResultValidationErrorDto>>(errorContent);
				foreach (var error in validationErrors)
				{
					ModelState.AddModelError(error.propertyName, error.errorMessage);
				}

				return View();
			}
		}
	}
}
