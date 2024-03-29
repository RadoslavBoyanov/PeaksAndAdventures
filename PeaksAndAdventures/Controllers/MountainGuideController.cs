﻿using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;
using static PeaksAndAdventures.Common.SuccessMessages;

namespace PeaksAndAdventures.Controllers
{
	public class MountainGuideController : BaseController
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
	            mountainGuideForm.TourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();
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

        [HttpGet]
        public async Task<IActionResult> AddRouteToMountainGuide(int id)
        {
	        var viewModel = await _mountainGuideService.GetMountainGuideAddRouteAsync(id);
	        if (viewModel == null)
	        {
		        return BadRequest(); 
	        }

	        if (viewModel.OwnerId != ClaimsPrincipalExtensions.Id(User))
	        {
		        return Unauthorized();
	        }

	        return View(viewModel);
        }


		[HttpPost]
        public async Task<IActionResult> AddRouteToMountainGuide(int id, int routeId, string ownerId)
        {
	        bool success = await _mountainGuideService.AddRouteToMountainGuideAsync(id, routeId, ownerId);

	        if (ClaimsPrincipalExtensions.Id(User) != ownerId)
	        {
		        return Unauthorized();
	        }


	        if (success)
	        {
		        return RedirectToAction("Details", "MountainGuide", new{id = id});
	        }
	        else
	        {
		        return BadRequest(FailAddRouteToMountainGuide);
	        }
        }

		[HttpGet]
		public async Task<IActionResult> AddMountainToMountainGuide(int id)
		{
			var mountainGuide = await _mountainGuideService.GetMountainGuideAddMountainAsync(id);
			if (mountainGuide is null)
			{
				return BadRequest();
			}

			if (mountainGuide.OwnerId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			return View(mountainGuide);
		}

		[HttpPost]
		public async Task<IActionResult> AddMountainToMountainGuide(int id, int mountainId, string ownerId)
		{
			bool success = await _mountainGuideService.AddMountainToMountainGuideAsync(id, mountainId, ownerId);

			if (ClaimsPrincipalExtensions.Id(User) != ownerId)
			{
				return Unauthorized();
			}

			if (success)
			{
				return RedirectToAction("Details", "MountainGuide", new { id = id });
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRoutes(int id)
		{
			var allRoutes = await _mountainGuideService.GetAllRoutesAsync(id);
			return View(allRoutes);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMountains(int id)
		{
			var allMountains = await _mountainGuideService.GetAllMountainsAsync(id);
			return View(allMountains);
		}

	}
}
