using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.QueryModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.Constants;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Controllers
{
	public class HutController : BaseController
	{
		private readonly IHutService _hutService;
		private readonly IMountainService _mountainService;

		public HutController(
			IHutService hutService,
			IMountainService mountainService)
		{
			_hutService = hutService;
			_mountainService = mountainService;
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> AddHut()
		{
			var hut = new AddHutViewModel()
			{
				Mountains = await _mountainService.GetAllMountains()
			};

			return View(hut);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
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

		public async Task<IActionResult> All([FromQuery] AllHutsQueryModel query)
        {
            var queryResult = _hutService.All(
                query.WorkTime.GetDisplayName(),
                query.Camping.GetDisplayName(),
                query.SearchTerm,
                query.MountainName,
                query.CurrentPage,
                AllHutsQueryModel.HutsPerPage);

			query.TotalHutsCount = queryResult.TotalHuts;
			query.Huts = queryResult.Huts;


			return View(query);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.DetailsAsync(id);
			return View(hut);
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.DeleteGetAsync(id);
			return View(hut);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			await _hutService.DeleteConfirmedAsync(id);
			return RedirectToAction("All", "Hut");
		}

		[HttpGet]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var hut = await _hutService.EditGetAsync(id);
			return View(hut);
		}

		[HttpPost]
		[Authorize(Roles = $"{AdminRole}, {MountaineerRole}, {TourAgencyRole}")]
		public async Task<IActionResult> Edit(HutEditViewModel hutForm)
		{
			if (hutForm is null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(hutForm);
			}

			await _hutService.EditPostAsync(hutForm);
			return RedirectToAction("All", "Hut");
		}

		[HttpGet]
		public async Task<IActionResult> GetRoutesToHut(int id)
		{
			if (!await _hutService.CheckHutExistsByIdAsync(id))
			{
				return BadRequest();
			}

			var routes = await _hutService.GetRoutesAsync(id);
			return View(routes);
		} 
	}
}
