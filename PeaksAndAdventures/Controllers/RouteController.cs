using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class RouteController : Controller
	{
		private readonly IRouteService _routeService;

		public RouteController(IRouteService routeService)
		{
			_routeService = routeService;
		}

		public async Task<IActionResult> All()
		{
			var allRoutes = await _routeService.GetAllRoutesAsync();
			return View(allRoutes);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var route = await _routeService.DetailsAsync(id);

			if (route is null)
			{
				return NotFound();
			}

			return View(route);
		}
	}
}
