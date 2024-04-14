using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;
using static PeaksAndAdventures.Common.Constants;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class WaterfallController : BaseController
	{
		private readonly IWaterfallService _waterfallService;
		private readonly IMountainService _mountainService;


		public WaterfallController(
			IWaterfallService waterfallService,
			IMountainService mountainService)
		{
			_waterfallService = waterfallService;
			_mountainService = mountainService;
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> AddWaterfall()

		{
			var waterfall = new WaterfallAddViewModel
			{
				Mountains = await _mountainService.GetAllMountains()
			};

			return View(waterfall);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> AddWaterfall(WaterfallAddViewModel waterfallForm)
		{
			bool isWaterfallExist = await _waterfallService.CheckWaterfallExistsByNameAsync(waterfallForm.Name);

			if (isWaterfallExist)
			{
				ModelState.AddModelError(nameof(waterfallForm.Name), WaterfallIsAlreadyExist);
				waterfallForm.Mountains = await _mountainService.GetAllMountains();
				return View(waterfallForm);
			}

			if (!ModelState.IsValid)
			{
				waterfallForm.Mountains = await _mountainService.GetAllMountains();
				return View(waterfallForm);
			}

			await _waterfallService.AddWaterfallToMountain(waterfallForm);
			return RedirectToAction("All", "Waterfall");
		}

		public async Task<IActionResult> All(int page = 1, int pageSize = 3)
		{
			var (waterfallsPerPage, totalPages) = await _waterfallService.AllWaterfallsPaginationAsync(page, pageSize);

            if (waterfallsPerPage is null)
            {
                return NotFound();
            }

			ViewBag.TotalPages = totalPages;
			ViewBag.Page = page;
			ViewBag.PageSize = pageSize;


			return View(waterfallsPerPage);
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
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
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
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
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
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
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
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
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

		[HttpGet]
		public async Task<IActionResult> GetRoutesToWaterfall(int id)
		{
			if (!await _waterfallService.CheckWaterfallExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var routes = await _waterfallService.GetRoutesForWaterfallAsync(id);
			return View(routes);
		}
	}
}
