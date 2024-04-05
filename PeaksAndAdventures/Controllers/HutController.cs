using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;

namespace PeaksAndAdventures.Controllers
{
	public class HutController : BaseController
	{
		private readonly IHutService _hutService;

		public HutController(IHutService hutService)
		{
			_hutService = hutService;
		}

		public async Task<IActionResult> All()
		{
			var allHuts = await _hutService.AllAsync();
			return View(allHuts);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.DetailsAsync(id);
			return View(hut);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.DeleteGetAsync(id);
			return View(hut);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			await _hutService.DeleteConfirmedAsync(id);
			return RedirectToAction("All", "Hut");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.EditGetAsync(id);
			return View(hut);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(HutEditViewModel hutForm)
		{
			if (hutForm is null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(hutForm);
			}

			await _hutService.EditPostAsync(hutForm);
			return RedirectToAction("All", "Hut");
		}
	}
}
