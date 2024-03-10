using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

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
    }
}
