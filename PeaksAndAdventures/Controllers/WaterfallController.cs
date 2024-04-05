using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Waterfall;

namespace PeaksAndAdventures.Controllers
{
	public class WaterfallController : BaseController
	{
		private readonly IWaterfallService _waterfallService;

		public WaterfallController(IWaterfallService waterfallService)
		{
			_waterfallService = waterfallService;
		}

		public async Task<IActionResult> All()
		{
			var allWaterfalls = await _waterfallService.AllAsync();
			return View(allWaterfalls);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (!await _waterfallService.CheckWaterfallExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var waterfall = await _waterfallService.DetailsAsync(id);
			return View(waterfall);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (!await _waterfallService.CheckWaterfallExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var waterfall = await _waterfallService.DeleteGetAsync(id);
			return View(waterfall);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!await _waterfallService.CheckWaterfallExistsByIdAsync(id))
			{
				return BadRequest();
			}

			await _waterfallService.DeleteConfirmedAsync(id);
			return RedirectToAction("All", "Waterfall");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _waterfallService.CheckWaterfallExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var waterfall = await _waterfallService.EditGetAsync(id);
			return View(waterfall);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(WaterfallEditViewModel waterfallForm)
		{
			if (waterfallForm is null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(waterfallForm);
			}

			await _waterfallService.EditPostAsync(waterfallForm);
			return RedirectToAction("All", "Waterfall");
		}
	}
}
