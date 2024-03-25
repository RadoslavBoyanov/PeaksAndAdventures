using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class TourAgencyController : Controller
	{
		private readonly ITourAgencyService _tourAgencyService;

		public TourAgencyController(ITourAgencyService tourAgencyService)
		{
			_tourAgencyService = tourAgencyService;
		}


		public async Task<IActionResult> All()
		{
			var allTourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			return View(allTourAgencies);
		}
	}
}
