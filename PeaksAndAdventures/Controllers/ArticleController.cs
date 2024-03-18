using Microsoft.AspNetCore.Mvc;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Article;
using PeaksAndAdventures.Extensions;
using static PeaksAndAdventures.Common.ErrorMessages;

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

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var article = new ArticleAddViewModel();

			return View(article);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ArticleAddViewModel articleForm)
		{
			if (!ModelState.IsValid)
			{
				return View(articleForm);
			}

			bool isExistArticleWithTheSameName = await _articleService.CheckIfArticleIsExistByNameAsync(articleForm.Title);

			if (isExistArticleWithTheSameName)
			{
				ModelState.AddModelError(nameof(articleForm.Title), ArticleWithTheSameName);
				return View(articleForm);
			}

			string userId = ClaimsPrincipalExtensions.Id(User);

			await _articleService.WriteArticleAsync(articleForm, userId);

			return RedirectToAction(nameof(All));
		}
	}
}
