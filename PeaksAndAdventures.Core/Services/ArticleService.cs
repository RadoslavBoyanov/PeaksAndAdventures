﻿using Microsoft.EntityFrameworkCore;
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
	}
}
