using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class LakeController : BaseController
	{
		private readonly ILakeService _lakeService;

		public LakeController(ILakeService lakeService)
		{
			_lakeService = lakeService;
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			var allLakes = await _lakeService.AllAsync();
			return View(allLakes);
		}
	}
}
