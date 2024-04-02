using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Route;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
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

		public async Task<RouteEditViewModel> EditGetAsync(int routeId)
		{
			var currentRoute = await _repository.All<Route>()
				.FirstOrDefaultAsync(r => r.Id == routeId);

			var routeHuts = await _repository.All<RouteHut>()
				.Where(rh => rh.RouteId == routeId)
				.Select(rh => rh.HutId)
				.ToListAsync();

			var routeLakes = await _repository.All<RouteLake>()
				.Where(rl => rl.RouteId == routeId)
				.Select(rl => rl.LakeId)
				.ToListAsync();

			var routePeaks = await _repository.All<RoutePeak>()
				.Where(rp => rp.RouteId == routeId)
				.Select(rp => rp.PeakId)
				.ToListAsync();

			var routeWaterfalls = await _repository.All<RouteWaterfall>()
				.Where(rw => rw.RouteId == routeId)
				.Select(rw => rw.WaterfallId)
				.ToListAsync();

			var routeEdit = new RouteEditViewModel()
			{
				Id = currentRoute.Id,
				Name = currentRoute.Name,
				StartingPoint = currentRoute.StartingPoint,
				Description = currentRoute.Description,
				Difficulty = currentRoute.Difficulty,
				DisplacementPositive = currentRoute.DisplacementPositive,
				DisplacementNegative = currentRoute.DisplacementNegative,
				Duration = currentRoute.Duration,
				ImageUrl = currentRoute.ImageUrl,
				SelectedHutsIds = routeHuts,
				SelectedLakesIds = routeLakes,
				SelectedPeaksIds = routePeaks,
				SelectedWaterfallsIds = routeWaterfalls,
				Huts = await _repository.AllReadOnly<Hut>()
					.Select(h => new AllHutsViewModel()
					{
						Id = h.Id,
						Name = h.Name,
					})
					.ToListAsync(),
				Lakes = await _repository.AllReadOnly<Lake>()
				.Select(l => new AllLakesViewModel()
				{
						Id = l.Id,
						Name = l.Name,
					})
					.ToListAsync(),
				Peaks = await _repository.AllReadOnly<Peak>()
					.Select(p => new AllPeaksViewModel()
					{
						Id = p.Id,
						Name = p.Name,
					})
				.ToListAsync(),
				Waterfalls = await _repository.AllReadOnly<Waterfall>()
					.Select(w => new AllWaterfallsViewModel()
					{
						Id = w.Id,
						Name = w.Name,
					})
					.ToListAsync(),
			};

			return routeEdit;
		}

		public async Task<int> EditPostAsync(RouteEditViewModel routeForm,
			List<int> selectedPeaksIds,
			List<int> selectedHutsIds,
			List<int> selectedLakesIds,
			List<int> selectedWaterfallsIds)
		{
			var route = await _repository.All<Route>()
				.Where(r => r.Id == routeForm.Id)
				.FirstOrDefaultAsync();

			route.Name = routeForm.Name;
			route.StartingPoint = routeForm.StartingPoint;
			route.Description = routeForm.Description;
			route.Difficulty = routeForm.Difficulty;
			route.DisplacementPositive = routeForm.DisplacementPositive;
			route.DisplacementNegative = routeForm.DisplacementNegative;
			route.Duration = routeForm.Duration;
			route.ImageUrl = routeForm.ImageUrl;

			await _repository.SaveChangesAsync();

			var existingRoutePeaks = await _repository.All<RoutePeak>()
				.Where(rp => rp.RouteId == route.Id)
				.ToListAsync();

			var existingRouteHuts = await _repository.All<RouteHut>()
				.Where(rh => rh.RouteId == route.Id)
				.ToListAsync();

			var existingRouteLakes = await _repository.All<RouteLake>()
				.Where(rl => rl.RouteId == route.Id)
				.ToListAsync();

			var existingRouteWaterfalls = await _repository.All<RouteWaterfall>()
				.Where(rw => rw.RouteId == route.Id)
				.ToListAsync();


			foreach (var hutId in routeForm.SelectedHutsIds)
			{
				var hut = await _repository.GetByIdAsync<Hut>(hutId);
				if (hut != null)
				{
					var existingRouteHut = await _repository.All<RouteHut>()
						.FirstOrDefaultAsync(rh => rh.RouteId == route.Id && rh.HutId == hutId);

					if (existingRouteHut is null)
					{
						var routeHut = new RouteHut()
						{
							RouteId = route.Id,
							Route = route,
							Hut = hut,
							HutId = hut.Id,
						};
						await _repository.AddAsync(routeHut);
					}
				}
			}

			foreach (var routeHut in existingRouteHuts)
			{
				if (!routeForm.SelectedHutsIds.Contains(routeHut.HutId))
				{
					_repository.Delete(routeHut);
				}
			}

			foreach (var peakId in routeForm.SelectedPeaksIds)
			{
				var peak = await _repository.GetByIdAsync<Peak>(peakId);
				if (peak != null)
				{

					var existingRoutePeak = await _repository.All<RoutePeak>()
						.FirstOrDefaultAsync(rp => rp.RouteId == route.Id && rp.PeakId == peakId);

					if (existingRoutePeak is null)
					{
						var routePeak = new RoutePeak()
						{
							RouteId = route.Id,
							Route = route,
							Peak = peak,
							PeakId = peak.Id,
						};
						await _repository.AddAsync(routePeak);
					}
				}
			}

			foreach (var routePeak in existingRoutePeaks)
			{
				if (!routeForm.SelectedPeaksIds.Contains(routePeak.PeakId))
				{
					_repository.Delete(routePeak);
				}
			}

			foreach (var lakeId in routeForm.SelectedLakesIds)
			{
				var lake = await _repository.GetByIdAsync<Lake>(lakeId);
				if (lake != null)
				{
					var existingRouteLake = await _repository.All<RouteLake>()
						.FirstOrDefaultAsync(rl => rl.RouteId == route.Id && rl.LakeId == lakeId);

					if (existingRouteLake is null)
					{
						var routeLake = new RouteLake()
						{
							RouteId = route.Id,
							Route = route,
							Lake = lake,
							LakeId = lake.Id,
						};
						await _repository.AddAsync(routeLake);
					}
				}
			}

			foreach (var routeLake in existingRouteLakes)
			{
				if (!routeForm.SelectedLakesIds.Contains(routeLake.LakeId))
				{
					_repository.Delete(routeLake);
				}
			}

			foreach (var waterfallId in routeForm.SelectedWaterfallsIds)
			{
				var waterfall = await _repository.GetByIdAsync<Waterfall>(waterfallId);
				if (waterfall != null)
				{
					var existingRouteWaterfall = await _repository.All<RouteWaterfall>()
						.FirstOrDefaultAsync(rw => rw.RouteId == route.Id && rw.WaterfallId == waterfallId);

					if (existingRouteWaterfall is null)
					{
						var routeWaterfall = new RouteWaterfall()
						{
							RouteId = route.Id,
							Route = route,
							Waterfall = waterfall,
							WaterfallId = waterfall.Id,
						};
						await _repository.AddAsync(routeWaterfall);
					}
				}
			}

			foreach (var routeWaterfall in existingRouteWaterfalls)
			{
				if (!routeForm.SelectedWaterfallsIds.Contains(routeWaterfall.WaterfallId))
				{
					_repository.Delete(routeWaterfall);
				}
			}

			await _repository.SaveChangesAsync();

			return route.Id;
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

		public async Task<RouteDeleteViewModel> DeleteAsync(int routeId)
		{
			var route = await _repository.AllReadOnly<Route>()
				.Include(r => r.RoutesHuts)
				.ThenInclude(h => h.Hut)
				.Include(r => r.RoutesLakes)
				.ThenInclude(l => l.Lake)
				.Include(r => r.RoutesPeaks)
				.ThenInclude(p => p.Peak)
				.Include(r => r.RoutesWaterfalls)
				.ThenInclude(w => w.Waterfall)
				.Include(r => r.MountaineersRoutes)
				.ThenInclude(mr => mr.MountainGuide)
				.FirstOrDefaultAsync(r => r.Id == routeId);

			var mountain = await _repository.GetByIdAsync<Mountain>(route.MountainId);

			var routeDelete = new RouteDeleteViewModel()
			{
				Name = route.Name,
				StartingPoint = route.StartingPoint,
				Description = route.Description,
				MountainName = mountain.Name,
				ImageUrl = route.ImageUrl,
			};

			return routeDelete;
		}

		public async Task<int> DeleteConfirmedAsync(int routeId)
		{
			var route = await _repository.AllReadOnly<Route>()
				.Include(r => r.RoutesHuts)
				.ThenInclude(h => h.Hut)
				.Include(r => r.RoutesLakes)
				.ThenInclude(l => l.Lake)
				.Include(r => r.RoutesPeaks)
				.ThenInclude(p => p.Peak)
				.Include(r => r.RoutesWaterfalls)
				.ThenInclude(w => w.Waterfall)
				.Include(r => r.MountaineersRoutes)
				.ThenInclude(mr => mr.MountainGuide)
				.FirstOrDefaultAsync(r => r.Id == routeId);

			if (route.RoutesHuts.Any())
			{
				foreach (var routeHut in route.RoutesHuts.ToList())
				{
					_repository.Delete(routeHut);
				}
			}

			if (route.RoutesLakes.Any())
			{
				foreach (var routeLake in route.RoutesLakes.ToList())
				{
					_repository.Delete(routeLake);
				}
			}

			if (route.RoutesPeaks.Any())
			{
				foreach (var routePeak in route.RoutesPeaks.ToList())
				{
					_repository.Delete(routePeak);
				}
			}

			if (route.RoutesWaterfalls.Any())
			{
				foreach (var routeWaterfall in route.RoutesWaterfalls.ToList())
				{
					_repository.Delete(routeWaterfall);
				}
			}

			if (route.MountaineersRoutes.Any())
			{
				foreach (var mountaineerRoute in route.MountaineersRoutes.ToList())
				{
					_repository.Delete(mountaineerRoute);
				}
			}

			await _repository.DeleteAsync<Route>(routeId);
			await _repository.SaveChangesAsync();

			return routeId;
		}

		public Task RateAsync(int routeId, double rating)
		{
			throw new NotImplementedException();
		}
	}
}
