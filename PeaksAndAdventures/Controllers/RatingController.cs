using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Areas.Admin.Controllers;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.Constants;
using static PeaksAndAdventures.Common.ErrorMessages;
using static PeaksAndAdventures.Extensions.CookieHelper;

namespace PeaksAndAdventures.Controllers
{
	public class RatingController : BaseController
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
		public async Task<IActionResult> AddRatingAsync(int id, string entityType, int value)
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

			string userId = User.Id();
			string cookieNameHash = CalculateHash($"{userId}_{entityType}_{id}");

			if (HttpContext.Request.Cookies[cookieNameHash] != null)
			{
				return BadRequest(YouCanVoteOnlyOnce);
			}

			HttpContext.Response.Cookies.Append(cookieNameHash, "true", new CookieOptions

			{
				Expires = DateTime.UtcNow.AddDays(7),
				HttpOnly = true,
				SameSite = SameSiteMode.Strict,
				Secure = true
			});

			await _ratingService.AddRatingAsync(id, entityType, (int)value);
			return RedirectToAction(  "Details" ,entityType, new { id = id, area = "" });
		}


		[HttpPost]
		[Authorize(Roles = AdminRole)]

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
			return RedirectToAction("Details", entityType, new { id = id });
		}
	}
}
