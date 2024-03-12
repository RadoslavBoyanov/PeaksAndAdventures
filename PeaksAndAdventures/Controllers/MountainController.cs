using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Mountain;

namespace PeaksAndAdventures.Controllers
{
	public class MountainController : BaseController
    {
        private readonly IMountainService _mountainService;

        public MountainController(IMountainService mountainService)
        {
            _mountainService = mountainService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allMountains = await _mountainService.AllAsync();
            return View(allMountains);
        }

        [HttpGet]
        public async Task<IActionResult> AllPeaksInMountain(int id)
        {
	        var allpeaksInMountain = await _mountainService.GetAllPeaksAsync(id);
            return View(allpeaksInMountain);
        }

        public async Task<IActionResult> AllHutsInMountain(int id)
        {
	        var allHutsInMountain = await _mountainService.GetAllHutsAsync(id);
            return View(allHutsInMountain);
        }

        public async Task<IActionResult> AllLakesInMountain(int id)
        {
	        var allLakesInMountain = await _mountainService.GetAllLakesAsync(id);
            return View(allLakesInMountain);
        }

        public async Task<IActionResult> AllWaterfallsInMountain(int id)
        {
	        var allWaterfallsInMountain = await _mountainService.GetAllWaterfallsAsync(id);
            return View(allWaterfallsInMountain);
        }

        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> Add()
        {
	        var mountain = new MountainFormViewModel();

	        return View(mountain);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(MountainFormViewModel mountainForm)
        {
	        bool montainExist = await _mountainService.CheckMountainExistsAsync(mountainForm.Name);

	        if (montainExist)
	        {
                ModelState.AddModelError(string.Empty, "Планината вече съществува.");
                return View(mountainForm);
	        }

	        if (!ModelState.IsValid)
	        {
		        return View(mountainForm);
	        }

	        await _mountainService.AddAsync(mountainForm);
            return View(mountainForm);
        }
    }
}
