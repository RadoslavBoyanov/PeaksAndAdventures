using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class RatingController : Controller
	{
		private readonly IRatingService _ratingService;

		public RatingController(IRatingService ratingService)
		{
			_ratingService = ratingService;
		}

		[HttpPost]
		public async Task<IActionResult> AddRatingAsync(int id, string entityType , int value)
		{
			await _ratingService.AddRatingAsync(id, entityType, (int)value);
			return RedirectToAction("Details", entityType, new { id = id });
		}

		[HttpGet]
		public async Task<IActionResult> GetAverageRatingAsync(int id)
		{
			var averageRating = await _ratingService.GetAverageRatingAsync(id);
			return Ok(averageRating);
		}

	}
}
