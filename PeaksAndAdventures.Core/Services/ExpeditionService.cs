using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class ExpeditionService : IExpeditionService
	{
		private readonly IRepository _repository;

		public ExpeditionService(IRepository repository)
		{
			_repository = repository;
		}
	}
}
