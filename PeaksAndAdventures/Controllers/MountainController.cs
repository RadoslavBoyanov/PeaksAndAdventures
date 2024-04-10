using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Lake;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
    public class MountainController : BaseController
    {
        private readonly IMountainService _mountainService;
        private readonly IPeakService _peakService;
        private readonly ILakeService _lakeService;
        private readonly IWaterfallService _waterfallService;
		private readonly IHutService _hutService;

        public MountainController(
	        IMountainService mountainService, 
	        IPeakService peakService, 
	        ILakeService lakeService, 
	        IWaterfallService waterfallService,
	        IHutService hutService)
        {
            _mountainService = mountainService;
            _peakService = peakService;
            _lakeService = lakeService;
            _waterfallService = waterfallService;
            _hutService = hutService;
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

        [HttpGet]
        public async Task<IActionResult> AddHut()
        {
	        var hut = new AddHutViewModel()
	        {
				Mountains = await _mountainService.GetAllMountains()
	        };

			return View(hut);
        }

        [HttpPost]
        public async Task<IActionResult> AddHut(AddHutViewModel hutForm)
        {
	        bool isHutExist = await _hutService.CheckHutExistsByNameAsync(hutForm.Name);
	        
	        if (isHutExist)
	        {
		        ModelState.AddModelError(nameof(hutForm.Name), HutIsAlreadyExist);
		        hutForm.Mountains = await _mountainService.GetAllMountains();
		        return View(hutForm);
	        }

	        if (!ModelState.IsValid)
	        {
		        hutForm.Mountains = await _mountainService.GetAllMountains();
				return View(hutForm);
	        }

	        await _hutService.AddHutToMountainAsync(hutForm);
	        return RedirectToAction("All", "Hut");
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
