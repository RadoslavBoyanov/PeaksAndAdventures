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

		public async Task AddAsync(RouteAddViewModel routeForm,
			List<int> selectedPeaksIds, 
			List<int> selectedHutsIds,
			List<int> selectedLakesIds,
			List<int> selectedWaterfallsIds)
		{
			var mountain = await _repository.GetByIdAsync<Mountain>(routeForm.MountainId);

			var route = new Route()
			{
				Name = routeForm.Name,
				StartingPoint = routeForm.StartingPoint,
				Description = routeForm.Description,
				Difficulty = routeForm.Difficulty,
				DisplacementPositive = routeForm.DisplacementPositive,
				DisplacementNegative = routeForm.DisplacementNegative,
				Duration = routeForm.Duration,
				ImageUrl = routeForm.ImageUrl,
				MountainId = routeForm.MountainId,
				Mountain = mountain,
			};

			await _repository.AddAsync(route);

			foreach (var hut in selectedHutsIds)
			{
				var hutByIdAsync = await _repository.GetByIdAsync<Hut>(hut);

				if (hutByIdAsync != null)
				{
					var routeHut = new RouteHut()
					{
						RouteId = route.Id,
						Route = route,
						Hut = hutByIdAsync,
						HutId = hutByIdAsync.Id,
					};
					await _repository.AddAsync(routeHut);
				}
			}

			foreach (var lake in selectedLakesIds)
			{
				var lakeByIdAsync = await _repository.GetByIdAsync<Lake>(lake);

				if (lakeByIdAsync != null)
				{
					var routeLake = new RouteLake()
					{
						RouteId = route.Id,
						Route = route,
						Lake = lakeByIdAsync,
						LakeId = lakeByIdAsync.Id,
					};
					await _repository.AddAsync(routeLake);
				}
			}

			foreach (var peak in selectedPeaksIds)
			{
				var peakByIdAsync = await _repository.GetByIdAsync<Peak>(peak);

				if (peakByIdAsync != null)
				{
					var routePeak = new RoutePeak()
					{
						RouteId = route.Id,
						Route = route,
						Peak = peakByIdAsync,
						PeakId = peakByIdAsync.Id,
					};
					await _repository.AddAsync(routePeak);
				}
			}

			foreach (var waterfall in selectedWaterfallsIds)
			{
				var waterfallByIdAsync = await _repository.GetByIdAsync<Waterfall>(waterfall);

				if (waterfallByIdAsync != null)
				{
					var routeWaterfall = new RouteWaterfall()
					{
						RouteId = route.Id,
						Route = route,
						Waterfall = waterfallByIdAsync,
						WaterfallId = waterfallByIdAsync.Id,
					};
					await _repository.AddAsync(routeWaterfall);
				}
			}

			await _repository.SaveChangesAsync();
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

		public async Task<bool> CheckIfExistRouteByName(string routeName)
		{
			return await _repository.AllReadOnly<Route>()
				.AnyAsync(r => r.Name == routeName);
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
