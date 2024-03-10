using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

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
    }
}
