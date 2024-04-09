using PeaksAndAdventures.Core.Models.ViewModels.Article;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IArticleService
	{
		Task<IEnumerable<ArticleAllViewModel>> AllAsync();
		Task<bool> CheckIfArticleIsExistByNameAsync(string articleTitle);
		Task<bool> CheckIfArticleIsExistByIdAsync(int articleId);
		Task<ArticleDetailsViewModel> DetailsAsync(int articleId);
		Task WriteArticleAsync(ArticleAddViewModel articleForm, string userId);
		Task<ArticleEditViewModel> EditGetAsync(int articleId);
		Task<int> EditPostAsync(ArticleEditViewModel articleForm);
		Task<ArticleDeleteViewModel> DeleteGetAsync(int articleId);
		Task<Article> DeletePostAsync(int articleId);
		Task<IEnumerable<ArticleAllViewModel>> UserArticlesAsync(string userId);
	}
}
