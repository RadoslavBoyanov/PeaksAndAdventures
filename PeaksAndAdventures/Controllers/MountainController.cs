using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class MountainController : BaseController
    {
        private readonly IMountainService _mountainService;
        private readonly IPeakService _peakService;
        private readonly ILakeService _lakeService;
        private readonly IWaterfallService _waterfallService;

        public MountainController(
	        IMountainService mountainService, 
	        IPeakService peakService, 
	        ILakeService lakeService, 
	        IWaterfallService waterfallService)
        {
            _mountainService = mountainService;
            _peakService = peakService;
            _lakeService = lakeService;
            _waterfallService = waterfallService;
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
	        bool isMountainExist = await _mountainService.CheckMountainExistsByNameAsync(mountainForm.Name);

	        if (isMountainExist)
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
	        var isPeakExist = await _peakService.CheckPeakExistsByNameAsync(peakForm.Name);
	        if (isPeakExist)
	        {
                ModelState.AddModelError(nameof(peakForm.Name), PeakIsAlreadyExist);
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
        public async Task<IActionResult> AddLake()
        {
	        var lake = new LakeAddViewModel
	        {
		        Mountains = await _mountainService.GetAllMountains()
	        };

	        return View(lake);
        }

        [HttpPost]
        public async Task<IActionResult> AddLake(LakeAddViewModel lakeForm)
        {
	        bool isLakeExist = await _lakeService.CheckLakeExistsByNameAsync(lakeForm.Name);

	        if (isLakeExist)
	        {
		        ModelState.AddModelError(nameof(lakeForm.Name), LakeIsAlreadyExist);
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
        public async Task<IActionResult> AddWaterfall()
        
        {
	        var waterfall = new WaterfallAddViewModel
	        {
		        Mountains = await _mountainService.GetAllMountains()
	        };

	        return View(waterfall);
        }

        [HttpPost]
        public async Task<IActionResult> AddWaterfall(WaterfallAddViewModel waterfallForm)
        {
	        bool isWaterfallExist = await _waterfallService.CheckWaterfallExistsByNameAsync(waterfallForm.Name);

	        if (isWaterfallExist)
	        {
		        ModelState.AddModelError(nameof(waterfallForm.Name), WaterfallIsAlreadyExist);
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
