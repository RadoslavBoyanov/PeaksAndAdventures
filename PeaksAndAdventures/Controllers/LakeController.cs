using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Lake;

namespace PeaksAndAdventures.Controllers
{
	public class LakeController : BaseController
	{
		private readonly ILakeService _lakeService;

		public LakeController(ILakeService lakeService)
		{
			_lakeService = lakeService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			var allLakes = await _lakeService.AllAsync();
			return View(allLakes);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _lakeService.CheckLakeExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var lake = await _lakeService.EditGetAsync(id);
			return View(lake);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(LakeEditViewModel lakeForm)
		{
			if (lakeForm is null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(lakeForm);
			}

			await _lakeService.EditPostAsync(lakeForm);
			return RedirectToAction("All", "Lake");
		}
	}
}
