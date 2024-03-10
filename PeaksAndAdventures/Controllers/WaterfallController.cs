using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class WaterfallController : BaseController
	{
		private readonly IWaterfallService _waterfallService;

		public WaterfallController(IWaterfallService waterfallService)
		{
			_waterfallService = waterfallService;
		}

		public async Task<IActionResult> All()
		{
			var allWaterfalls = await _waterfallService.AllAsync();
			return View(allWaterfalls);
		}
	}
}
