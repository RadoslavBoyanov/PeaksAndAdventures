﻿using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class MountainGuideController : Controller
	{
		private readonly IMountainGuideService _mountainGuideService;

		public MountainGuideController(IMountainGuideService mountainGuideService)
		{
			_mountainGuideService = mountainGuideService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var allMountainGuides = await _mountainGuideService.AllAsync();
			
			return View(allMountainGuides);
		}
	}
}