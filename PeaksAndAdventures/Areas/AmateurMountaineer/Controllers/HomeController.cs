using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Areas.AmateurMountaineer.Controllers
{
	[Authorize(Roles = AmateurMountaineerRole)]
	[Area("AmateurMountaineer")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
