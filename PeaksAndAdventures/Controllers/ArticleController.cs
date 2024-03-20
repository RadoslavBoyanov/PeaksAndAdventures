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

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await _articleService.CheckIfArticleIsExistByIdAsync(id))
			{
				return BadRequest();
			}

			var currentArticle = await _articleService.EditGetAsync(id);

			if (currentArticle.AuthorId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			return View(currentArticle);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ArticleEditViewModel articleEditView)
		{
			if (articleEditView is null)
			{
				return BadRequest();
			}

			if (articleEditView.AuthorId != ClaimsPrincipalExtensions.Id(User))
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View(articleEditView);
			}

			await _articleService.EditPostAsync(articleEditView);
			return RedirectToAction("All", "Article");
		}

		[HttpGet]
		public async Task<IActionResult> UserArticles()
		{
			var articles = await _articleService.GetAllArticlesWithDetailsAsync();

			var userId = ClaimsPrincipalExtensions.Id(User);

			var userArticles = articles.Where(a => a.AuthorId == userId);

			return View(userArticles);
		}
	}
}
