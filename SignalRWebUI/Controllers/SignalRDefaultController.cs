using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class SignalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
