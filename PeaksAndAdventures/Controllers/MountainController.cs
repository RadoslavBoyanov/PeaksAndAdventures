using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class MountainController : BaseController
    {
        private readonly IMountainService _mountainService;

        public MountainController(
	        IMountainService mountainService)
        {
            _mountainService = mountainService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int page = 1, int pageSize = 6)
        {
            var (mountainsPerPage, totalPages ) = await _mountainService.AllMountainsPaginationAsync(page, pageSize);
            if (mountainsPerPage is null)
            {
	            return NotFound();
            }

			ViewBag.TotalPages = totalPages;
			ViewBag.Page = page;
			ViewBag.PageSize = pageSize;


            return View(mountainsPerPage);
        }

        [HttpGet]
        public async Task<IActionResult> AllPeaksInMountain(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }
			var allpeaksInMountain = await _mountainService.GetAllPeaksAsync(id);
            return View(allpeaksInMountain);
        }

        public async Task<IActionResult> AllHutsInMountain(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }
			var allHutsInMountain = await _mountainService.GetAllHutsAsync(id);
            return View(allHutsInMountain);
        }

        public async Task<IActionResult> AllLakesInMountain(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }
			var allLakesInMountain = await _mountainService.GetAllLakesAsync(id);
            return View(allLakesInMountain);
        }

        public async Task<IActionResult> AllWaterfallsInMountain(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }
	        var allWaterfallsInMountain = await _mountainService.GetAllWaterfallsAsync(id);
            return View(allWaterfallsInMountain);
        }

		[HttpGet]
        public async Task<IActionResult> AllRoutesInMountain(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }
			var allRoutesInMountain = await _mountainService.GetAllRoutesAsync(id);
			return View(allRoutesInMountain);
		}

        [HttpGet]
        [Authorize(Roles = "Admin, Mountaineer, TourAgency")]
		public IActionResult Add()
        {
	        var mountain = new MountainFormViewModel();

	        return View(mountain);
        }

        [HttpPost]
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
        public async Task<IActionResult> Add(MountainFormViewModel mountainForm)
        {
	        bool isMountainExist = await _mountainService.CheckMountainExistsByNameAsync(mountainForm.Name);

	        if (isMountainExist)
	        {
                ModelState.AddModelError(string.Empty, MountainIsAlreadyExist);
                return View(mountainForm);
	        }

	        if (!ModelState.IsValid)
	        {
		        return View(mountainForm);
	        }

	        await _mountainService.AddAsync(mountainForm);
            return RedirectToAction("All", "Mountain");
        }

        [HttpGet]
		[Authorize(Roles = "Admin, Mountaineer, TourAgency")]
        public async Task<IActionResult> Edit(int id)
        {
	        if (!await _mountainService.CheckMountainExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }

            var mountain = await _mountainService.EditGetAsync(id);
	        return View(mountain);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Mountaineer, TourAgency")]
		public async Task<IActionResult> Edit(MountainEditViewModel mountainEdit)
        {
	        if (mountainEdit is null)
	        {
		        return BadRequest();
	        }

	        if (!ModelState.IsValid)
	        {
		        return View(mountainEdit);
	        }

			await _mountainService.EditPostAsync(mountainEdit);
	        return RedirectToAction("All", "Mountain");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
	        var mountain =  await _mountainService.DetailsAsync(id);

	        if (mountain is null)
	        {
		        return BadRequest();
	        }

	        return View(mountain);
        }
    }
}
