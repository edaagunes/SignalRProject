using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class FoodRapidApiController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
				Headers =
	{
		{ "x-rapidapi-key", "8189ffcc04msh89957af40346776p12f8ebjsndc8eef993d4e" },
		{ "x-rapidapi-host", "tasty.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
				var values = root.Results;
				foreach (var recipe in values)
				{
					recipe.Name = TranslateStatic(recipe.Name);
				}
				return View(values.ToList());
			}

		}

		private static readonly Dictionary<string, string> TranslationDictionary = new Dictionary<string, string>
{
	{ "Low-Carb Avocado Chicken Salad", "Avokadolu Tavuk Salatası" },
	{ "Tomato And Anchovy Pasta", "Domates Soslu Makarna" },
	{ "One-Pot Lemon Garlic Shrimp Pasta", "Limonlu Sarımsaklı Karidesli Makarna" },
	{ "Chocolate Mug Cake", "Çikolatalı Fincan Kek" },
	{ "3-Ingredient Teriyaki Chicken", "3 Malzemeli Teriyaki Tavuk" },
	{ "3 Ingredient Peanut Butter Cookies", "3 Malzemeli Fıstık Ezmesi Kurabiyeleri" },
	{ "Whipped Coffee", "Çırpılmış Kahve" },
	{ "Creamy Chicken Penne Pasta", "Kremalı Tavuklu Penne Makarna" },
	{ "Garlic Shrimp Bacon Alfredo", "Sarımsaklı Karidesli Ve Baconlı Alfredo Soslu Makarna" },
	{ "Easy One-Pot Mac ‘n’ Cheese", "Kolay Tek Tencere Mac ‘n’ Cheese" },
	{ "Garlic Shrimp Scampi", "Sarımsaklı Karidesli Şkampi" },
	{ "Birthday Cake Mug Cake", "Doğum Günü Fincan Keki" },
	{ "Microwave 5-Minute Mac 'N' Cheese", "Mikrodalgada 5 Dakikada Mac ‘N’ Cheese" },
	{ "Milkshake: The Tiffany", "Milkshake: The Tiffany" },
	{ "Spaghetti With Garlic And Oil", "Sarımsaklı Ve Zeytinyağlı Spagetti" },
	{ "Weekday Meal-Prep Pesto Chicken & Veggies", "Günlük Öğün Hazırlığı Pesto Tavuk & Sebzeler" },
};


		public string TranslateStatic(string text)
		{
			return TranslationDictionary.ContainsKey(text) ? TranslationDictionary[text] : text;
		}

	}
}
