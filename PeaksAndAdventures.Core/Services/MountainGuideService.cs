using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using PeaksAndAdventures.Core.Models.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.Models.ViewModels.Route;
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
			var mountainGuideRoute = await _repository.GetByIdsAsync<MountaineerRoute>(new object[] { mountainGuideId, routeId });

			if (mountainGuide is null || route is null || mountainGuide.OwnerId != ownerId)
			{
				return false;
			}

			if (mountainGuideRoute != null)
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

		public async Task<bool> AddMountainToMountainGuideAsync(int id, int mountainId, string ownerId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(id);
			var mountain = await _repository.GetByIdAsync<Mountain>(mountainId);
			var mountainGuideMountain = await _repository.GetByIdsAsync<MountaineerMountain>(new object[] { id, mountainId });

			if (mountainGuide is null || mountain is null || mountainGuide.OwnerId != ownerId)
			{
				return false;
			}

			if (mountainGuideMountain != null)
			{
				return false;
			}

			var mountaineerMountain = new MountaineerMountain()
			{
				MountainId = mountainId,
				Mountain = mountain,
				MountainGuideId = id,
				MountainGuide = mountainGuide
			};

			mountainGuide.MountaineersMountains.Add(mountaineerMountain);

			await _repository.SaveChangesAsync();
			return true;
		}

		public async Task<bool> CheckIfExistMountainGuideByIdAsync(int mountainGuideId)
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.AnyAsync(mg => mg.Id == mountainGuideId);
		}

		public async Task<bool> CheckIfExistMountainGuideByOwnerIdAsync(string ownerId)
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.AnyAsync(mg => mg.OwnerId == ownerId);
		}

		public async Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.AllReadOnly<MountainGuide>()
                .Include(mg => mg.TourAgency)
                .FirstOrDefaultAsync(mg => mg.Id == mountainGuideId);

			var mountainGuideInformation = new MountainGuideDetailsViewModel()
			{
				Id = mountainGuide.Id,
				FirstName = mountainGuide.FirstName,
				LastName = mountainGuide.LastName,
				Age = mountainGuide.Age.ToString(),
				Email = mountainGuide.Email,
				Phone = mountainGuide.Phone,
				Experience = mountainGuide.Experience,
				ImageUrl = mountainGuide.ImageUrl,
				OwnerId = mountainGuide.OwnerId,
            };

            if (mountainGuide.TourAgency != null)
            {
                mountainGuideInformation.TourAgencyId = mountainGuide.TourAgencyId;
                mountainGuideInformation.TourAgencyName = mountainGuide.TourAgency.Name;
                mountainGuideInformation.TourAgencyPhone = mountainGuide.TourAgency.Phone;
                mountainGuideInformation.TourAgencyEmail = mountainGuide.TourAgency.Email;
            }

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

			MountainGuideEditViewModel mountainGuide;

			if (currentMountainGuide?.TourAgency is null)
			{
				mountainGuide = new MountainGuideEditViewModel()
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
				};
			}
			else
			{
				mountainGuide = new MountainGuideEditViewModel()
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
			}

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

		public async Task<MountainGuideAddRouteViewModel> GetMountainGuideAddRouteAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);

			if (mountainGuide == null || mountainGuide.OwnerId == null)
			{
				return null; // Ако планинският водач или ownerId не съществуват, върнете null
			}

			// Извличане на списък от маршрути, които вече са добавени към планинския водач
			var addedRouteIds = await _repository
				.AllReadOnly<MountaineerRoute>()
				.Where(mgr => mgr.MountainGuideId == mountainGuideId)
				.Select(mgr => mgr.RouteId)
				.ToListAsync();

			// Извличане на списък от маршрути, които все още не са добавени към планинския водач
			var routesToAdd = await _repository
				.AllReadOnly<Route>()
				.Where(r => !addedRouteIds.Contains(r.Id)) // Филтриране на маршрутите, които не са вече добавени
				.ToListAsync();

			var viewModel = new MountainGuideAddRouteViewModel
			{
				Id = mountainGuide.Id,
				OwnerId = mountainGuide.OwnerId,
				Routes = routesToAdd.Select(r => new GetAllRoutesViewModel { Id = r.Id, Name = r.Name })
			};

			return viewModel;
		}

		public async Task<MountainGuideAddMountainViewModel> GetMountainGuideAddMountainAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);

			if (mountainGuide == null || mountainGuide.OwnerId == null)
			{
				return null; // Ако планинският водач или ownerId не съществуват, върнете null
			}

			// Извличане на списък от планини, които вече са добавени към планинския водач
			var addedMountainIds = await _repository
				.AllReadOnly<MountaineerMountain>()
				.Where(mgm => mgm.MountainGuideId == mountainGuideId)
				.Select(mgm => mgm.MountainId)
				.ToListAsync();

			// Извличане на списък от планини, които все още не са добавени към планинския водач
			var mountainsToAdd = await _repository
				.AllReadOnly<Mountain>()
				.Where(m => !addedMountainIds.Contains(m.Id)) // Филтриране на планините, които не са вече добавени
				.ToListAsync();

			var viewModel = new MountainGuideAddMountainViewModel()
			{
				Id = mountainGuide.Id,
				OwnerId = mountainGuide.OwnerId,
				Mountains = mountainsToAdd.Select(mountain => new GetAllMountainsViewModel() { Id = mountain.Id, Name = mountain.Name })
			};

			return viewModel;
		}

		public async Task<IEnumerable<AllMountainsViewModel>> GetAllMountainsAsync(int mountainGuideId)
		{
			return await _repository
				.AllReadOnly<Mountain>()
				.Where(m => m.MountaineersMountains.Any(mm => mm.MountainGuideId == mountainGuideId))
				.Select(mm => new AllMountainsViewModel()
				{
					Id = mm.Id,
					Name = mm.Name,
					ImageUrls = mm.ImageUrls
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync(int mountainGuideId)
		{
			return await _repository
				.AllReadOnly<Route>()
				.Where(r => r.MountaineersRoutes.Any(mr => mr.MountainGuideId == mountainGuideId))
				.Select(mr => new GetAllRoutesViewModel()
				{
					Id = mr.Id,
					Name = mr.Name,
					ImageUrl = mr.ImageUrl
				})
				.ToListAsync();
		}
	}
}
