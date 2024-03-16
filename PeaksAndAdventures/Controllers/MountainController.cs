using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class MountainController : BaseController
    {
        private readonly IMountainService _mountainService;
        private readonly IPeakService _peakService;
        private readonly ILakeService _lakeService;

        public MountainController(
	        IMountainService mountainService, 
	        IPeakService peakService, 
	        ILakeService lakeService)
        {
            _mountainService = mountainService;
            _peakService = peakService;
            _lakeService = lakeService;
        }

        [HttpGet]
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
        public IActionResult Add()
        {
	        var mountain = new MountainFormViewModel();

	        return View(mountain);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MountainFormViewModel mountainForm)
        {
	        bool montainExist = await _mountainService.CheckMountainExistsByNameAsync(mountainForm.Name);

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
            return RedirectToAction("All", "Mountain");
        }

        [HttpGet]
        public async Task<IActionResult> AddPeak()
        {
	        var peak = new PeakAddViewModel()
	        {
                Mountains = await _mountainService.GetAllMountains(),
	        };
	        return View(peak);
        }

        [HttpPost]
        public async Task<IActionResult> AddPeak(PeakAddViewModel peakForm)
        {
	        if (!ModelState.IsValid)
	        {
		        peakForm.Mountains = await _mountainService.GetAllMountains();
		        return View(peakForm);
	        }

	        await _peakService.AddPeakToMountainAsync(peakForm);
	        return RedirectToAction("All", "Peak");
        }

        [HttpGet]
        public async Task<IActionResult> AddLake()
        {
	        var lake = new LakeAddViewModel();
	        lake.Mountains = await _mountainService.GetAllMountains();

            return View(lake);
        }

        [HttpPost]
        public async Task<IActionResult> AddLake(LakeAddViewModel lakeForm)
        {
	        if (!ModelState.IsValid)
	        {
		        lakeForm.Mountains = await _mountainService.GetAllMountains();
                return View(lakeForm);
	        }

	        await _lakeService.AddLakeToMountainAsync(lakeForm);
	        return RedirectToAction("All", "Lake");
        }

        [HttpGet]
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
