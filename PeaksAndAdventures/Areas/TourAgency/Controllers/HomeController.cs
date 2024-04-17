using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Areas.TourAgency.Controllers
{
	[Authorize(Roles = TourAgencyRole)]
	[Area("TourAgency")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
