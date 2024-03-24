using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.ViewModels.Route;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
	public class MountainGuideService : IMountainGuideService
	{
		private readonly IRepository _repository;

		public MountainGuideService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task AddAsync(MountainGuideAddViewModel mountainGuideForm)
		{
			var tourAgency = await _repository.GetByIdAsync<TourAgency>(mountainGuideForm.TourAgencyId);
			var owner = await  _repository.GetByIdAsync<IdentityUser>(mountainGuideForm.OwnerId);

			var mountainGuide = new MountainGuide()
			{
				FirstName = mountainGuideForm.FirstName,
				LastName = mountainGuideForm.LastName,
				Age = mountainGuideForm.Age,
				Email = mountainGuideForm.Email,
				Phone = mountainGuideForm.Phone,
				Experience = mountainGuideForm.Experience,
				ImageUrl = mountainGuideForm.ImageUrl,
				TourAgencyId = mountainGuideForm.TourAgencyId,
				TourAgency = tourAgency,
				OwnerId = mountainGuideForm.OwnerId,
				Owner = owner
			};

			await _repository.AddAsync(mountainGuide);
			await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<MountainGuideAllViewModel>> AllAsync()
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.Select(mg => new MountainGuideAllViewModel()
				{
					Id = mg.Id,
					FirstName = mg.FirstName,
					LastName = mg.LastName,
					ImageUrl = mg.ImageUrl,
				})
				.ToListAsync();
		}

		public async Task<bool> AddRouteToMountainGuideAsync(int mountainGuideId, int routeId, string ownerId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);
			var route = await _repository.GetByIdAsync<Route>(routeId);
			var mountaineGuideRoute = await _repository.GetByIdsAsync<MountaineerRoute>(new object[] { mountainGuideId, routeId });

			if (mountainGuide is null || route is null || mountainGuide.OwnerId != ownerId)
			{
				return false;
			}

			if (mountaineGuideRoute != null)
			{
				return false;
			}

			var mountaineerRoute = new MountaineerRoute
			{
				MountainGuideId = mountainGuideId,
				MountainGuide = mountainGuide,
				Route = route,
				RouteId = routeId,
			};


			mountainGuide.MountaineersRoutes.Add(mountaineerRoute);

			await _repository.SaveChangesAsync();

			return true;
		}

		public async Task<bool> CheckIfExistMountainGuideByIdAsync(int mountainGuideId)
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.AnyAsync(mg => mg.Id == mountainGuideId);
		}

		public async Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(mountainGuide.TourAgencyId);
			string tourAgencyName = tourAgency?.Name ?? string.Empty;

			var mountainGuideInformation = new MountainGuideDetailsViewModel()
			{
				Id = mountainGuide.Id,
				FirstName = mountainGuide.FirstName,
				LastName = mountainGuide.LastName,
				Age = mountainGuide.Age.ToString(),
				Email = mountainGuide.Email,
				Phone = mountainGuide.Phone,
				Experience = mountainGuide.Experience,
				Rating = mountainGuide.Rating.ToString(),
				ImageUrl = mountainGuide.ImageUrl,
				OwnerId = mountainGuide.OwnerId,
				TourAgencyId = mountainGuide.TourAgencyId,
				TourAgencyName = tourAgencyName,
			};

			return mountainGuideInformation;
		}

		public async Task<MountainGuideDeleteViewModel> DeleteGetAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.AllReadOnly<MountainGuide>()
				.Include(mg => mg.MountaineersRoutes)
				.ThenInclude(r => r.Route)
				.Include(mg => mg.MountaineersMountains)
				.ThenInclude(m => m.Mountain)
				.FirstOrDefaultAsync(mg => mg.Id == mountainGuideId);

			if (mountainGuide == null)
			{
				// Обработка на сценария, при който планинският водач не е намерен
				return null;
			}

			var deleteForm = new MountainGuideDeleteViewModel()
			{
				FirstName = mountainGuide.FirstName,
				LastName = mountainGuide.LastName,
				Email = mountainGuide.Email,
				ImageUrl = mountainGuide.ImageUrl,
				OwnerId = mountainGuide.OwnerId,
				Routes = mountainGuide.MountaineersRoutes
					.Where(r => r.Route != null) // Филтриране на null обекти
					.Select(r => new GetAllRoutesViewModel()
					{
						Id = r.RouteId,
						Name = r.Route.Name
					}).ToList(),
				Mountains = mountainGuide.MountaineersMountains
					.Where(m => m.Mountain != null) // Филтриране на null обекти
					.Select(m => new GetAllMountainsViewModel()
					{
						Id = m.MountainId,
						Name = m.Mountain.Name,
					}).ToList()
			};

			return deleteForm;
		}


		public async Task<int> DeleteConfirmedAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);

			// Зареждане на планинските водачи с пълните данни за маршрути и планини
			mountainGuide = await _repository.All<MountainGuide>()
				.Include(mg => mg.MountaineersRoutes)
				.Include(mg => mg.MountaineersMountains)
				.FirstOrDefaultAsync(mg => mg.Id == mountainGuideId);

			// Изтриване на всички връзки между планинския водач и маршрутите
			foreach (var route in mountainGuide.MountaineersRoutes.ToList())
			{
				_repository.Delete(route);
			}

			// Изтриване на всички връзки между планинския водач и планините
			foreach (var mountain in mountainGuide.MountaineersMountains.ToList())
			{
				_repository.Delete(mountain);
			}

			// Изтриване на самия планински водач
			await _repository.DeleteAsync<MountainGuide>(mountainGuideId);
			await _repository.SaveChangesAsync();

			return mountainGuide.Id;
		}



		public async Task<MountainGuideEditViewModel> EditGetAsync(int mountainGuideId)
		{
			var currentMountainGuide = await _repository.All<MountainGuide>()
				.Include(mg => mg.TourAgency)
				.FirstOrDefaultAsync(mg => mg.Id == mountainGuideId);

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(currentMountainGuide.TourAgencyId);
			var owner = await _repository.GetByIdAsync<IdentityUser>(currentMountainGuide.OwnerId);

			var mountainGuide = new MountainGuideEditViewModel()
			{
				Id = currentMountainGuide.Id,
				FirstName = currentMountainGuide.FirstName,
				LastName = currentMountainGuide.LastName,
				Age = currentMountainGuide.Age,
				Email = currentMountainGuide.Email,
				Phone = currentMountainGuide.Phone,
				Experience = currentMountainGuide.Experience,
				ImageUrl = currentMountainGuide.ImageUrl,
				OwnerId = currentMountainGuide.OwnerId,
				TourAgencyId = currentMountainGuide.TourAgencyId,
				TourAgencyName = currentMountainGuide.TourAgency.Name
			};

			return mountainGuide;
		}

		public async Task<int> EditPostAsync(MountainGuideEditViewModel mountainGuideEdit)
		{
			var mountaineGuide = await _repository.All<MountainGuide>()
				.Include(mg => mg.TourAgency)
				.Where(mg => mg.Id == mountainGuideEdit.Id)
				.FirstOrDefaultAsync();

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(mountaineGuide.TourAgencyId);
			var owner = await _repository.GetByIdAsync<IdentityUser>(mountaineGuide.OwnerId);

			mountaineGuide.FirstName = mountainGuideEdit.FirstName;
			mountaineGuide.LastName = mountainGuideEdit.LastName;
			mountaineGuide.Age = mountainGuideEdit.Age;
			mountaineGuide.Email = mountainGuideEdit.Email;
			mountaineGuide.Phone = mountainGuideEdit.Phone;
			mountaineGuide.Experience = mountainGuideEdit.Experience;
			mountaineGuide.ImageUrl = mountainGuideEdit.ImageUrl;
			mountaineGuide.TourAgencyId = mountainGuideEdit.TourAgencyId;
			mountaineGuide.Owner = owner;
			mountaineGuide.TourAgency = tourAgency;


			await _repository.SaveChangesAsync();

			return mountaineGuide.Id;
		}

		public async Task<MountainGuideAddRouteViewModel> GetMountainGuideAddRouteViewModelAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);
			var ownerId = mountainGuide.OwnerId;

			if (mountainGuide == null || ownerId == null)
			{
				return null; // Ако планинският водач или ownerId не съществуват, върнете null
			}

			var routes = await _repository.AllReadOnly<Route>().ToListAsync();

			var viewModel = new MountainGuideAddRouteViewModel
			{
				Id = mountainGuide.Id,
				OwnerId = ownerId,
				Routes = routes.Select(r => new GetAllRoutesViewModel { Id = r.Id, Name = r.Name })
			};

			return viewModel;
		}

	}
}
