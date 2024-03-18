using PeaksAndAdventures.Core.ViewModels.Article;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IArticleService
	{
		Task<IEnumerable<ArticleAllViewModel>> AllAsync();
		Task<bool> CheckIfArticleIsExistByNameAsync(string articleTitle);
		Task<ArticleDetailsViewModel> DetailsAsync(int articleId);
		Task WriteArticleAsync(ArticleAddViewModel articleform, string userId);
	}
}
