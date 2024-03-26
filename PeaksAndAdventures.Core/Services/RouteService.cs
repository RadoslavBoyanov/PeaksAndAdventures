using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Route;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
	public class RouteService : IRouteService
	{
		private readonly IRepository _repository;

		public RouteService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync()
		{
			return await _repository.AllReadOnly<Route>()
				.Select(r => new GetAllRoutesViewModel()
				{
					Id = r.Id,
					Name = r.Name
				})
				.ToListAsync();
		}
	}
}
