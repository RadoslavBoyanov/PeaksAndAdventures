using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;

namespace PeaksAndAdventures.Controllers
{
	public class ArticleController : BaseController
	{
		private readonly IArticleService _articleService;

		public ArticleController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public async Task<IActionResult> All()
		{
			var allArticles = await _articleService.AllAsync();
			return View(allArticles);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var article = await _articleService.DetailsAsync(id);

			if (article is null)
			{
				return NotFound();
			}

			return View(article);
		}
	}
}
