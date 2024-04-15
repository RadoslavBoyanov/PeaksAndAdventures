using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Areas.Admin.Controllers
{
	public class RatingController : BaseAdminController
	{
		private readonly IRatingService _ratingService;
		private readonly IRouteService _routeService;
		private readonly ITourAgencyService _tourAgencyService;
		private readonly IMountainGuideService _mountainGuideService;

		public RatingController(
			IRatingService ratingService, 
			IRouteService routeService,
			ITourAgencyService tourAgencyService, 
			IMountainGuideService mountainGuideService)
		{
			_ratingService = ratingService;
			_routeService = routeService;
			_tourAgencyService = tourAgencyService;
			_mountainGuideService = mountainGuideService;
		}


		[HttpPost]

		public async Task<IActionResult> DeleteRatings(int id, string entityType)
		{
			if (entityType == TourAgencyConst)
			{
				if (!await _tourAgencyService.CheckIfExistTourAgencyByIdAsync(id))
				{
					return NotFound();
				}
			}

			if (entityType == RouteConst)
			{
				if (!await _routeService.CheckIfExistRouteById(id))
				{
					return NotFound();
				}
			}

			if (entityType == MountainGuideConst)
			{
				if (!await _mountainGuideService.CheckIfExistMountainGuideByIdAsync(id))
				{
					return NotFound();
				}
			}

			await _ratingService.DeleteRatings(id, entityType);
			return RedirectToAction( "Details" ,entityType, new { id = id });
		}
	}
}
