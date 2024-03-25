using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.TourAgency;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class TourAgencyController : BaseController
	{
		private readonly ITourAgencyService _tourAgencyService;

		public TourAgencyController(ITourAgencyService tourAgencyService)
		{
			_tourAgencyService = tourAgencyService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allTourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();

			return View(allTourAgencies);
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

			return View(tourAgency);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
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
	}
}
