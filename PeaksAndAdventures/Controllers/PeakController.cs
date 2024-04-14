using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using static PeaksAndAdventures.Common.Constants;
using static PeaksAndAdventures.Common.ErrorMessages;
using static PeaksAndAdventures.Common.SuccessMessages;

namespace PeaksAndAdventures.Controllers
{
	public class PeakController : BaseController
    {
        private readonly IPeakService _peakService;
		private readonly IMountainService _mountainService;

        public PeakController(
	        IPeakService peakService, 
	        IMountainService mountainService)
        {
	        _peakService = peakService;
	        _mountainService = mountainService;
        }

        [HttpGet]
        [Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
        public async Task<IActionResult> AddPeak()
        {
	        var peak = new PeakAddViewModel()
	        {
		        Mountains = await _mountainService.GetAllMountains(),
	        };
	        return View(peak);
        }

        [HttpPost]
        [Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
        public async Task<IActionResult> AddPeak(PeakAddViewModel peakForm)
        {
	        var isPeakExist = await _peakService.CheckPeakExistsByNameAsync(peakForm.Name);
	        if (isPeakExist)
	        {
		        ModelState.AddModelError(nameof(peakForm.Name), PeakIsAlreadyExist);
		        peakForm.Mountains = await _mountainService.GetAllMountains();
		        return View(peakForm);
	        }

	        if (!ModelState.IsValid)
	        {
		        peakForm.Mountains = await _mountainService.GetAllMountains();
		        return View(peakForm);
	        }

	        await _peakService.AddPeakToMountainAsync(peakForm);
	        return RedirectToAction("All", "Peak");
        }

		[HttpGet]
		public async Task<IActionResult> All(int page = 1, int pageSize = 10)
		{
			var (peaksPerPage, totalPages) = await _peakService.AllPaginationAsync(page, pageSize);

			if (peaksPerPage is null)
			{
				return NotFound();
			}

			ViewBag.TotalPages = totalPages;
			ViewBag.Page = page;
			ViewBag.PageSize = pageSize;

			return View(peaksPerPage);
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> Edit(int id)
        {
	        if (!await _peakService.CheckPeakExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }

	        var peak = await _peakService.EditGetAsync(id);
            return View(peak);
        }

        [HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
        public async Task<IActionResult> Edit(PeakEditViewModel peakForm)
        {
	        if (peakForm is null)
	        {
		        return BadRequest();
	        }

	        if (!ModelState.IsValid)
	        {
		        return View(peakForm);
	        }

	        await _peakService.EditPostAsync(peakForm);
	        return RedirectToAction("All", "Peak");
        }

		[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
	        if (!await _peakService.CheckPeakExistsByIdAsync(id))
	        {
		        return NotFound();
	        }

            var peak = await _peakService.DetailsAsync(id);
            return View(peak);
        }

        [HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
        public async Task<IActionResult> Delete(int id)
        {
	        if (!await _peakService.CheckPeakExistsByIdAsync(id))
	        {
		        return NotFound();
	        }

	        var peak = await _peakService.DeleteGetAsync(id);
	        return View(peak);
		}

        [HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	        if (!await _peakService.CheckPeakExistsByIdAsync(id))
	        {
		        return NotFound();
	        }

	        await _peakService.DeleteConfirmedAsync(id);
	        return RedirectToAction("All", "Peak");
		}

        [HttpGet]
        public async Task<IActionResult> GetRoutesToPeak(int id)
        {
	        if (!await _peakService.CheckPeakExistsByIdAsync(id))
	        {
		        return BadRequest();
	        }

			var routes = await _peakService.GetRoutesToPeakAsync(id);
			return View(routes);
        }
    }
}
