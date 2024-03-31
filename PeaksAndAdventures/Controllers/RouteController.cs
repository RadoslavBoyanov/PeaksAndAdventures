using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Route;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class RouteController : Controller
	{
		private readonly IRouteService _routeService;
		private readonly IMountainService _mountainService;
		private readonly IHutService _hutService;
		private readonly ILakeService _lakeService;
		private readonly IPeakService _peakService;
		private readonly IWaterfallService _waterfallService;


		public RouteController(
			IRouteService routeService, 
			IMountainService mountainService, 
			IHutService hutService,
			ILakeService lakeService,
			IPeakService peakService,
			IWaterfallService waterfallService)
		{
			_routeService = routeService;
			_mountainService = mountainService;
			_hutService = hutService;
			_lakeService = lakeService;
			_peakService = peakService;
			_waterfallService = waterfallService;
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var route = new RouteAddViewModel()
			{
				Lakes = await _lakeService.AllAsync(),
				Peaks = await _peakService.AllAsync(),
				Huts = await _hutService.AllAsync(),
				Waterfalls = await _waterfallService.AllAsync(),
				Mountains = await _mountainService.GetAllMountains(),
			};

			return View(route);
		}

		[HttpPost]
		public async Task<IActionResult> Add(RouteAddViewModel routeForm)
		{
			if (await _routeService.CheckIfExistRouteByName(routeForm.Name))
			{
				routeForm.Lakes = await _lakeService.AllAsync();
				routeForm.Peaks = await _peakService.AllAsync();
				routeForm.Huts = await _hutService.AllAsync();
				routeForm.Waterfalls = await _waterfallService.AllAsync();
				routeForm.Mountains = await _mountainService.GetAllMountains();

				ModelState.AddModelError(nameof(routeForm.Name), RouteIsAlreadyExist);
				return View(routeForm);
			}

			if (!ModelState.IsValid)
			{
				routeForm.Lakes = await _lakeService.AllAsync();
				routeForm.Peaks = await _peakService.AllAsync();
				routeForm.Huts = await _hutService.AllAsync();
				routeForm.Waterfalls = await _waterfallService.AllAsync();
				routeForm.Mountains = await _mountainService.GetAllMountains();

				return View(routeForm);
			}

			await _routeService.AddAsync(routeForm,
				routeForm.SelectedPeaksIds, 
				routeForm.SelectedHutsIds, 
				routeForm.SelectedLakesIds, 
				routeForm.SelectedWaterfallsIds);
			return RedirectToAction("All", "Route");
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
