using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class ExpeditionController : BaseController
	{
		private readonly IExpeditionService _expeditionService;

		public ExpeditionController(IExpeditionService expeditionService)
		{
			_expeditionService = expeditionService;
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
	}
}
