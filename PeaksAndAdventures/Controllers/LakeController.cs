using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Lake;
using PeaksAndAdventures.Core.Services;
using static PeaksAndAdventures.Common.Constants;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class LakeController : BaseController
	{
		private readonly ILakeService _lakeService;
		private readonly IMountainService _mountainService;

		public LakeController(
			ILakeService lakeService,
			IMountainService mountainService)
		{
			_lakeService = lakeService;
			_mountainService = mountainService;
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> AddLake()
		{
			var lake = new LakeAddViewModel
			{
				Mountains = await _mountainService.GetAllMountains()
			};

			return View(lake);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> AddLake(LakeAddViewModel lakeForm)
		{
			bool isLakeExist = await _lakeService.CheckLakeExistsByNameAsync(lakeForm.Name);

			if (isLakeExist)
			{
				ModelState.AddModelError(nameof(lakeForm.Name), LakeIsAlreadyExist);
				lakeForm.Mountains = await _mountainService.GetAllMountains();
				return View(lakeForm);
			}

			if (!ModelState.IsValid)
			{
				lakeForm.Mountains = await _mountainService.GetAllMountains();
				return View(lakeForm);
			}

			await _lakeService.AddLakeToMountainAsync(lakeForm);
			return RedirectToAction("All", "Lake");
		}

		[HttpGet]
		public async Task<IActionResult> All(int page = 1, int pageSize = 3)
		{
			var (lakesPerPage, totalPages) = await _lakeService.AllPaginationAsync(page, pageSize);
			if (lakesPerPage is null)
			{
				return NotFound();
			}

			ViewBag.TotalPages = totalPages;
			ViewBag.Page = page;
			ViewBag.PageSize = pageSize;

			return View(lakesPerPage);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (!await _lakeService.CheckLakeExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var lake = await _lakeService.DetailsAsync(id);
			return View(lake);
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!await _lakeService.CheckLakeExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var lake = await _lakeService.DeleteGetAsync(id);
			return View(lake);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!await _lakeService.CheckLakeExistsByIdAsync(id))
			{
				return BadRequest();
			}

			await _lakeService.DeleteConfirmedAsync(id);
			return RedirectToAction("All", "Lake");
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
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
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
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

		[HttpGet]
		public async Task<IActionResult> GetRoutesToLake(int id)
		{
			if (!await _lakeService.CheckLakeExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var routes = await _lakeService.GetRoutesToLakeAsync(id);
			return View(routes);
		}
	}
}
