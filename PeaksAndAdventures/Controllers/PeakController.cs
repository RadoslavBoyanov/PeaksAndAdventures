using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using static PeaksAndAdventures.Common.Constants;

namespace PeaksAndAdventures.Controllers
{
	public class PeakController : BaseController
    {
        private readonly IPeakService _peakService;

        public PeakController(IPeakService peakService)
        {
            _peakService = peakService;
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
