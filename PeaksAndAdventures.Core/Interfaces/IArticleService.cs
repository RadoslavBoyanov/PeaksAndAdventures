using PeaksAndAdventures.Core.ViewModels.Article;
using PeaksAndAdventures.Core.ViewModels.Hut;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IArticleService
	{
		Task<IEnumerable<ArticleAllViewModel>> AllAsync();
		Task<ArticleDetailsViewModel> DetailsAsync(int articleId);
	}
}
