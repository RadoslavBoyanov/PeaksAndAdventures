using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Areas.MountainGuide.Controllers
{
	[Authorize(Roles = MountaineerRole)]
	[Area("MountainGuide")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
