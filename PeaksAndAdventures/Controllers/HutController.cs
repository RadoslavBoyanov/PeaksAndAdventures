using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class HutController : BaseController
	{
		private readonly IHutService _hutService;

		public HutController(IHutService hutService)
		{
			_hutService = hutService;
		}

		public async Task<IActionResult> All()
		{
			var allHuts = await _hutService.AllAsync();
			return View(allHuts);
		}
	}
}
