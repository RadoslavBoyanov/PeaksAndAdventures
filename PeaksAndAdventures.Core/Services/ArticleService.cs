using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Article;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;
using static PeaksAndAdventures.Common.EntityValidations.ArticleValidation;

namespace PeaksAndAdventures.Core.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IRepository _repository;

		public ArticleService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<ArticleAllViewModel>> AllAsync()
		{
			return await _repository.AllReadOnly<Article>()
				.Select(a => new ArticleAllViewModel()
				{
					Id = a.Id,
					Title = a.Title,
					ImageUrl = a.ImageUrl
				}).ToListAsync();
		}

		public async Task<bool> CheckIfArticleIsExistByNameAsync(string articleTitle)
		{
			return await _repository.AllReadOnly<Article>()
				.AnyAsync(a => a.Title == articleTitle);
		}

		public async Task<bool> CheckIfArticleIsExistByIdAsync(int articleId)
		{
			return await _repository.AllReadOnly<Article>()
				.AnyAsync(a => a.Id == articleId);
		}

		public async Task<ArticleDetailsViewModel> DetailsAsync(int articleId)
		{
			var article = await _repository.GetByIdAsync<Article>(articleId);

			var articleDetails = new ArticleDetailsViewModel()
			{
				Id = article.Id,
				Title = article.Title,
				Content = article.Content,
				ImageUrl = article.ImageUrl,
				DatePublish = article.DatePublish.ToString(DateTimeFormat),
				AuthorId = article.AuthorId
			};

			return articleDetails;
		}

		public async  Task WriteArticleAsync(ArticleAddViewModel articleAddView, string userId)
		{
			var article = new Article()
			{
				Title = articleAddView.Title,
				Content = articleAddView.Content,
				DatePublish = articleAddView.DatePublish,
				ImageUrl = articleAddView.ImageUrl,
				AuthorId = userId,
			};

			await _repository.AddAsync(article);
			await _repository.SaveChangesAsync();
		}

		public async Task<ArticleEditViewModel> EditGetAsync(int articleId)
		{
			var currentArticle = await _repository.All<Article>()
				.FirstOrDefaultAsync(a => a.Id == articleId);

			var article = new ArticleEditViewModel()
			{
				Id = currentArticle.Id,
				Title = currentArticle.Title,
				Content = currentArticle.Content,
				ImageUrl = currentArticle.ImageUrl,
				DatePublish = currentArticle.DatePublish,
				AuthorId = currentArticle.AuthorId,
			};

			return article;
		}

		public async Task<int> EditPostAsync(ArticleEditViewModel articleForm)
		{
			var article = await _repository.All<Article>()
				.Where(a => a.Id == articleForm.Id)
				.FirstOrDefaultAsync();

			article.Title = articleForm.Title;
			article.Content = articleForm.Content;
			article.ImageUrl = articleForm.ImageUrl;
			article.DatePublish = articleForm.DatePublish;

			await _repository.SaveChangesAsync();

			return article.Id;
		}

		public async Task<IEnumerable<ArticleDetailsViewModel>> GetAllArticlesWithDetailsAsync()
		{
			return await _repository.AllReadOnly<Article>()
				.Select(a => new ArticleDetailsViewModel()
				{
					Id = a.Id,
					Title = a.Title,
					Content = a.Content,
					ImageUrl = a.ImageUrl,
					DatePublish = a.DatePublish.ToString(DateTimeFormat),
					AuthorId = a.AuthorId
				}).ToListAsync();
		}

		public async Task<ArticleDeleteViewModel> DeleteGetAsync(int articleId)
		{
			var article = await _repository.AllReadOnly<Article>()
				.Where(a => a.Id == articleId)
				.FirstOrDefaultAsync();

			var deleteArticle = new ArticleDeleteViewModel()
			{
				Id = article.Id,
				Title = article.Title,
				ImageUrl = article.ImageUrl,
				AuthorId = article.AuthorId
			};

			return deleteArticle;
		}

		public async Task<Article> DeletePostAsync(int articleId)
		{
			var article = await _repository.GetByIdAsync<Article>(articleId);

			await _repository.DeleteAsync<Article>(articleId);
			await _repository.SaveChangesAsync();
			return article;
		}
	}
}
