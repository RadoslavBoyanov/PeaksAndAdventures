using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Peak;

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
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
	        var allPeaks = await _peakService.AllAsync();
	        return View(allPeaks);
        }

        [HttpGet]
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
        public async Task<IActionResult> Edit(PeakFormViewModel peakForm)
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
    }
}
