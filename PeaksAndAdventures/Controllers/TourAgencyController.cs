using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.TourAgency;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Controllers
{
	[Authorize(Roles = AdminRole)]
	public class TourAgencyController : BaseController
	{
		private readonly ITourAgencyService _tourAgencyService;
		private readonly IRatingService _ratingService;

		public TourAgencyController(ITourAgencyService tourAgencyService, 
			IRatingService ratingService)
		{
			_tourAgencyService = tourAgencyService;
			_ratingService = ratingService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allTourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			return View(allTourAgencies);
		}

		[HttpGet]
		public async Task<IActionResult> AllMountainGuidesInAgency(int id)
		{
			var allMountainGuides = await _tourAgencyService.AllMountainGuideInAgencyAsync(id);
			return View(allMountainGuides);
		}

		[HttpGet]
		public async Task<IActionResult> AllExpeditionsInAgency(int id)
		{
			var allExpeditions = await _tourAgencyService.GetExpeditionsInAgencyAsync(id);
			return View(allExpeditions);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var tourAgency = new TourAgencyAddViewModel();

			return View(tourAgency);
		}

		[HttpPost]
		public async Task<IActionResult> Add(TourAgencyAddViewModel tourAgencyForm)
		{
			if (await _tourAgencyService.CheckIfExistTourAgencyByName(tourAgencyForm.Name))
			{
				ModelState.AddModelError(nameof(tourAgencyForm.Name), AgencyWithThisNameIsExist);
				return View(tourAgencyForm);
			}

			if (!ModelState.IsValid)
			{
				return View(tourAgencyForm);
			}

			await _tourAgencyService.AddTourAgencyAsync(tourAgencyForm);
			return RedirectToAction("All", "TourAgency");
		}

		[HttpGet]

		public async Task<IActionResult> Details(int id)
		{
			var tourAgency = await _tourAgencyService.DetailsAsync(id);

			if (tourAgency is null)
			{
				return NotFound();
			}

			tourAgency.Rating = await _ratingService.GetAverageRatingByAgencyAsync(id);

			return View(tourAgency);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var tourAgency = await _tourAgencyService.DeleteGetAsync(id);

			if (tourAgency is null)
			{
				return NotFound();
			}

			if (tourAgency.OwnerId != User.Id() && !User.IsInRole(AdminRole))
			{
				return Unauthorized();
			}

			return View(tourAgency);
		}

		[HttpPost]
		[Authorize(Roles = AdminRole)]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var isExistTourAgency = await _tourAgencyService.CheckIfExistTourAgencyById(id);

			if (!isExistTourAgency)
			{
				return BadRequest();
			}

			var agency = await _tourAgencyService.DetailsAsync(id);
			if (agency.OwnerId != User.Id() && !User.IsInRole(AdminRole))
			{
				return Unauthorized();
			}

			var message = await _tourAgencyService.DeleteConfirmedAsync(id);

			if (message == CantDeleteTourAgencyBecauseOfExpeditionParticipant)
			{
				TempData["DeleteAgencyError"] = message;
				return View("DeleteConfirmed");
			}

			TempData["DeleteAgencySuccess"] = message;
			
			return View("DeleteConfirmed");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _tourAgencyService.CheckIfExistTourAgencyById(id))
			{
				return NotFound();
			}

			var currentTourAgency = await _tourAgencyService.EditGetAsync(id);

			if (currentTourAgency.OwnerId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			return View(currentTourAgency);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(TourAgencyEditViewModel tourAgencyForm)
		{
			if (tourAgencyForm is null)
			{
				return BadRequest();
			}

			if (tourAgencyForm.OwnerId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View();
			}

			await _tourAgencyService.EditPostAsync(tourAgencyForm);
			return RedirectToAction("Details", "TourAgency", new { id = tourAgencyForm.Id });
		}

		[HttpGet]
		public async Task<IActionResult> AgencyRatings(int id)
		{
			if (!await _tourAgencyService.CheckIfExistTourAgencyById(id))
			{
				return BadRequest();
			}

			var ratings = await _ratingService.GetRatingDistributionByAgencyAsync(id);
			return View(ratings);
		}
	}
}
