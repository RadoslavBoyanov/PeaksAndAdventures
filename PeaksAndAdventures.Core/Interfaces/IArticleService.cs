using PeaksAndAdventures.Core.ViewModels.Article;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IArticleService
	{
		Task<IEnumerable<ArticleAllViewModel>> AllAsync();
		Task<bool> CheckIfArticleIsExistByNameAsync(string articleTitle);
		Task<bool> CheckIfArticleIsExistByIdAsync(int articleId);
		//Task<ArticleDetailsViewModel> GetArticleId(int articleId);
		Task<ArticleDetailsViewModel> DetailsAsync(int articleId);
		Task WriteArticleAsync(ArticleAddViewModel articleForm, string userId);
		Task<ArticleEditViewModel> EditGetAsync(int articleId);
		Task<int> EditPostAsync(ArticleEditViewModel articleForm);
	}
}
