﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Expedition;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class ExpeditionController : BaseController
	{
		private readonly IExpeditionService _expeditionService;
		private readonly IRouteService _routeService;
		private readonly ITourAgencyService _tourAgencyService;

		public ExpeditionController(
			IExpeditionService expeditionService,
			IRouteService routeService,
            ITourAgencyService tourAgencyService)
		{
			_expeditionService = expeditionService;
			_routeService = routeService;
            _tourAgencyService = tourAgencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var expedition = new ExpeditionAddViewModel()
            {
                TourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync(),
                Routes = await _routeService.GetAllRoutesAsync()
            };
            return View(expedition);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpeditionAddViewModel expeditionForm)
        {
	        if (await _expeditionService.CheckIfExistExpeditionByNameAsync(expeditionForm.Name))
	        {
				expeditionForm.TourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();
				expeditionForm.Routes = await _routeService.GetAllRoutesAsync();
				ModelState.AddModelError(nameof(expeditionForm.Name), AgencyWithThisNameIsExist);
				return View(expeditionForm);
	        }

            if (!ModelState.IsValid)
            {
                expeditionForm.TourAgencies = await _tourAgencyService.GetAllTourAgenciesAsync();
				expeditionForm.Routes = await _routeService.GetAllRoutesAsync();
                return View(expeditionForm);
            }

            await _expeditionService.AddAsync(expeditionForm);
            return RedirectToAction("All", "Expedition");
        }

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allExpeditions = await _expeditionService.AllExpeditionGetAsync();
			return View(allExpeditions);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var expedition = await _expeditionService.DetailsAsync(id);

			if (expedition is null)
			{
				return NotFound();
			}

			return View(expedition);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _expeditionService.CheckIfExistExpeditionByIdAsync(id))
			{
				return BadRequest();
			}

			var currentExpedition = await _expeditionService.EditGetAsync(id);

			if (currentExpedition is null)
			{
				return BadRequest();
			}

			if (currentExpedition.OrganiserId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			return View(currentExpedition);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ExpeditionEditViewModel expeditionForm)
		{
			if (expeditionForm.OrganiserId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				expeditionForm.Routes = await _routeService.GetAllRoutesAsync();
				return View(expeditionForm);
			}

			await _expeditionService.EditPostAsync(expeditionForm);
			return RedirectToAction("Details", "Expedition", new { id = expeditionForm.Id });
		}

		[HttpPost]
		public async Task<IActionResult> JoinExpedition(int expeditionId, string userId)
		{
			var result = await _expeditionService.RegisterForExpeditionAsync(userId, expeditionId);

			if (result.Success)
			{
				return Ok(result.Message);
			}
			else
			{
				return BadRequest(result.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> LeaveExpedition(int expeditionId, string userId)
		{
			var result = await _expeditionService.UnregisterFromExpeditionAsync(userId, expeditionId);

			if (result.Success)
			{
				return Ok(result.Message);
			}
			else
			{
				return BadRequest(result.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> MyExpeditions()
		{
			var myExpeditions = await _expeditionService.UserExpeditionsAsync(ClaimsPrincipalExtensions.Id(User));
			return View(myExpeditions);
		}

	}
}
