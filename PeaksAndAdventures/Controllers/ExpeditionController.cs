using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Expedition;
using PeaksAndAdventures.Extensions;

namespace PeaksAndAdventures.Controllers
{
	public class ExpeditionController : BaseController
	{
		private readonly IExpeditionService _expeditionService;
		private readonly IRouteService _routeService;

		public ExpeditionController(
			IExpeditionService expeditionService,
			IRouteService routeService)
		{
			_expeditionService = expeditionService;
			_routeService = routeService;
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
			if (await _expeditionService.CheckIfExistExpeditionByNameAsync(expeditionForm.Name))
			{
				ModelState.AddModelError(nameof(expeditionForm.Name), "");
				expeditionForm.Routes = await _routeService.GetAllRoutesAsync();
				return View(expeditionForm);
			}

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
	}
}
