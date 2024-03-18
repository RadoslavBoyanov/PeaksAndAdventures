using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class RouteService : IRouteService
	{
		private readonly IRepository _repository;

		public RouteService(IRepository repository)
		{
			_repository = repository;
		}
	}
}
