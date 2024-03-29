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
					Name = r.Name,
					ImageUrl = r.ImageUrl,
				})
				.ToListAsync();
		}

		public async Task<bool> CheckIfExistRouteById(int routeId)
		{
			return await _repository.AllReadOnly<Route>()
				.AnyAsync(r => r.Id == routeId);
		}

		public async Task<RouteDetailsViewModel> DetailsAsync(int routeId)
		{
			var route = await _repository.GetByIdAsync<Route>(routeId);

			var mountain = await _repository.GetByIdAsync<Mountain>(route.MountainId);

			var routeDetails = new RouteDetailsViewModel()
			{
				Id = route.Id,
				Name = route.Name,
				StartingPoint = route.StartingPoint,
				Description = route.Description,
				Difficulty = route.Difficulty.ToString(),
				DisplacementPositive = route.DisplacementPositive,
				DisplacementNegative = route.DisplacementNegative,
				Duration = route.Duration,
				ImageUrl = route.ImageUrl,
				MountainId = route.MountainId,
				MountainName = mountain.Name,
			};

			return routeDetails;
		}
	}
}
