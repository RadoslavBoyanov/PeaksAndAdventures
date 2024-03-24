using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class MountainGuideController : Controller
	{
		private readonly IMountainGuideService _mountainGuideService;
		private readonly ITourAgencyService _tourAgencyService;

		public MountainGuideController(
            IMountainGuideService mountainGuideService, 
            ITourAgencyService tourAgencyService)
        {
            _mountainGuideService = mountainGuideService;
            _tourAgencyService = tourAgencyService;
        }

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allMountainGuides = await _mountainGuideService.AllAsync();
			
			return View(allMountainGuides);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var mountainGuide = await _mountainGuideService.DetailsAsync(id);

			if (mountainGuide is null)
			{
				return NotFound();
			}

			return View(mountainGuide);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _mountainGuideService.CheckIfExistMountainGuideByIdAsync(id))
			{
				return BadRequest();
			}

			var currentMountainGuide = await _mountainGuideService.EditGetAsync(id);

			if (currentMountainGuide.OwnerId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			return View(currentMountainGuide);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(MountainGuideEditViewModel mountainGuide)
        {
            var agency = await _tourAgencyService.GetTourAgencyByNameAsync(mountainGuide.TourAgencyName);

            if (agency is null)
            {
				ModelState.AddModelError(nameof(mountainGuide.TourAgencyName), TourAgencyNotExist);
                return View(mountainGuide);
            }

			mountainGuide.TourAgencyId = agency.Id;

			if (mountainGuide is null)
			{
				return BadRequest();
			}

			if (mountainGuide.OwnerId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
            {
				return View();
			}

			await _mountainGuideService.EditPostAsync(mountainGuide);
			return RedirectToAction("Details", "MountainGuide", new { id = mountainGuide.Id });
		}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var mountainGuide = new MountainGuideAddViewModel()
            {
                TourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync()
            };

            return View(mountainGuide);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MountainGuideAddViewModel mountainGuideForm)
        {
            if (!ModelState.IsValid)
            {
                return View(mountainGuideForm);
            }

            await _mountainGuideService.AddAsync(mountainGuideForm);
            return RedirectToAction("All", "MountainGuide");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
	        var deleteMountainGuide = await _mountainGuideService.DeleteGetAsync(id);

	        if (deleteMountainGuide is null)
	        {
		        return NotFound();
	        }

	        if (deleteMountainGuide.OwnerId != ClaimsPrincipalExtensions.Id(User))
	        {
		        return Unauthorized();
	        }

	        return View(deleteMountainGuide);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	        var isExistMountainGuide = await _mountainGuideService.CheckIfExistMountainGuideByIdAsync(id);

	        if (!isExistMountainGuide)
	        {
		        return NotFound();
	        }

	        var mountainGuide = await _mountainGuideService.DetailsAsync(id);
	        if (mountainGuide.OwnerId !=ClaimsPrincipalExtensions.Id(User))
	        {
		        return Unauthorized();
	        }

	        await _mountainGuideService.DeleteConfirmedAsync(id);
	        return RedirectToAction("All", "MountainGuide");

        }
	}
}
