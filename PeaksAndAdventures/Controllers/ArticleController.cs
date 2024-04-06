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
			if (allArticles is null)
			{
				return NotFound();
			}
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
			var myArticles = await _articleService.UserArticlesAsync(ClaimsPrincipalExtensions.Id(User));
			return View(myArticles);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var deleteArticle = await _articleService.DeleteGetAsync(id);

			if (deleteArticle == null)
			{
				return NotFound();
			}

			if (deleteArticle.AuthorId != ClaimsPrincipalExtensions.Id(User))
			{
				return Forbid();
			}

			return View(deleteArticle);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var isExistArticle = await _articleService.CheckIfArticleIsExistByIdAsync(id);

			if (!isExistArticle)
			{
				return NotFound();
			}

			var article = await _articleService.DetailsAsync(id);
			if (article.AuthorId != ClaimsPrincipalExtensions.Id(User))
			{
				return Forbid();
			}

			await _articleService.DeletePostAsync(id);
			return RedirectToAction("All" ,"Article");
		}
	}

	
}
