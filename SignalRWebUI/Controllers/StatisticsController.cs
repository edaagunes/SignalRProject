using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class StatisticsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
