using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IRepository _repository;

		public ArticleService(IRepository repository)
		{
			_repository = repository;
		}
	}
}
