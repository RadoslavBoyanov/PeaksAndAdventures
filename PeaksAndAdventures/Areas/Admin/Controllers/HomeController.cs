using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Extensions;

namespace PeaksAndAdventures.Areas.Admin.Controllers
{
	public class HomeController : BaseAdminController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
