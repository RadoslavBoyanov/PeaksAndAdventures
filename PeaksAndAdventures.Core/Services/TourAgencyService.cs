using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class TourAgencyService : ITourAgencyService
	{
		private readonly IRepository _repository;

		public TourAgencyService(IRepository repository)
		{
			_repository = repository;
		}
	}
}
