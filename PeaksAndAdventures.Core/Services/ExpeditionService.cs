using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Expedition;
using PeaksAndAdventures.Core.Models.ViewModels.Route;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;
using static PeaksAndAdventures.Common.EntityValidations.ExpeditionValidation;

namespace PeaksAndAdventures.Core.Services
{
    public class ExpeditionService : IExpeditionService
	{
		private readonly IRepository _repository;

		public ExpeditionService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task AddAsync(ExpeditionAddViewModel expeditionForm)
		{
			var organiser = await _repository.GetByIdAsync<IdentityUser>(expeditionForm.OrganiserId);
			var tourAgency = await _repository.GetByIdAsync<TourAgency>(expeditionForm.TourAgencyId);
			var route = await _repository.GetByIdAsync<Route>(expeditionForm.RouteId);

			var expedition = new Expedition()
			{
				Name = expeditionForm.Name,
				StartDate = expeditionForm.StartDate,
				EndDate = expeditionForm.EndDate,
				Days = expeditionForm.Days,
				Enrolment = expeditionForm.Enrolment,
				Includes = expeditionForm.Includes,
				Excludes = expeditionForm.Excludes,
				Program = expeditionForm.Program,
				Extras = expeditionForm.Extras,
				Price = expeditionForm.Price,
				OrganiserId = expeditionForm.OrganiserId,
				Organiser = organiser,
				RouteId = expeditionForm.RouteId,
				Route = route,
				TourAgencyId = expeditionForm.TourAgencyId,
				TourAgency = tourAgency,
			};
			await _repository.AddAsync(expedition);
			await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<ExpeditionAllViewModel>> AllExpeditionGetAsync()
		{
			return await _repository.AllReadOnly<Expedition>()
				.Select(e => new ExpeditionAllViewModel()
				{
					Id = e.Id,
					Name = e.Name,
					StartDate = e.StartDate.ToString(DateTimeFormat),
					EndDate = e.EndDate.ToString(DateTimeFormat),
					Price = e.Price.ToString()
				})
				.ToListAsync();
		}

		public async Task<bool> CheckIfExistExpeditionByIdAsync(int expeditionId)
		{
			return await _repository.AllReadOnly<Expedition>()
				.AnyAsync(e => e.Id == expeditionId);
		}

		public async Task<bool> CheckIfExistExpeditionByNameAsync(string expeditionName)
		{
			return await _repository.AllReadOnly<Expedition>()
				.AnyAsync(e => e.Name == expeditionName);
		}

		public async Task<ExpeditionDetailsViewModel> DetailsAsync(int expeditionId)
		{

			var expedition = await _repository.AllReadOnly<Expedition>().FirstOrDefaultAsync(e => e.Id == expeditionId);

			if (expedition is null)
			{
				return null;
			}

			var route = await _repository.GetByIdAsync<Route>(expedition.RouteId);
			string routeName = route != null ? route.Name : "Няма информация";

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(expedition.TourAgencyId);
			string tourAgencyName = tourAgency != null ? tourAgency.Name : "Няма информация";

			
			var expeditionDetails = new ExpeditionDetailsViewModel()
			{
				Id = expedition.Id,
				Name = expedition.Name,
				StartDate = expedition.StartDate.ToString(DateTimeFormat),
				EndDate = expedition.EndDate.ToString(DateTimeFormat),
				Price = expedition.Price,
				Days = expedition.Days,
				Enrolment = expedition.Enrolment,
				Program = expedition.Program,
				Includes = expedition.Includes,
				Excludes = expedition.Excludes,
				Extras = expedition.Extras,
				OrganiserId = expedition.OrganiserId,
				TourAgencyId = expedition.TourAgencyId,
				TourAgencyName = tourAgencyName,
				RouteId = expedition.RouteId,
				RouteName = routeName
			};

			

			return expeditionDetails;
		}

		public async Task<ExpeditionDeleteViewModel> DeleteGetAsync(int expeditionId)
		{
			var expedition = await _repository.All<Expedition>()
				.Include(e => e.ExpeditionsParticipants)
				.ThenInclude(ep => ep.Participant)
				.FirstOrDefaultAsync(e => e.Id == expeditionId);

			if (expedition is null)
			{
				return null;
			}

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(expedition.TourAgencyId);

			var expeditionDelete = new ExpeditionDeleteViewModel()
			{
				Id = expedition.Id,
				Name = expedition.Name,
				StartDate = expedition.StartDate.ToString(DateTimeFormat),
				EndDate = expedition.EndDate.ToString(DateTimeFormat),
				Price = expedition.Price.ToString(),
				TourAgencyName = tourAgency.Name,
				OrganiserId = expedition.OrganiserId
			};

			return expeditionDelete;
		}

		public async Task<int> DeleteConfirmedAsync(int expeditionId)
		{
			var expedition = await _repository.All<Expedition>()
				.Include(e => e.ExpeditionsParticipants)
				.ThenInclude(ep => ep.Participant)
				.FirstOrDefaultAsync(e => e.Id == expeditionId);

			if (expedition.ExpeditionsParticipants.Any())
			{
				foreach (var expeditionParticipant in expedition.ExpeditionsParticipants.ToList())
				{
					_repository.Delete(expeditionParticipant);
				}
			}

			_repository.Delete(expedition);
			await _repository.SaveChangesAsync();

			return expedition.Id;
		}

		public async Task<ExpeditionEditViewModel> EditGetAsync(int expeditionId)
		{
			var currentExpedition = await _repository.All<Expedition>()
				.FirstOrDefaultAsync(e => e.Id == expeditionId);

			var routes = await _repository.All<Route>()
				.Select(r => new GetAllRoutesViewModel()
				{
					Id = r.Id,
					Name = r.Name
				})
				.ToListAsync();

			var expedition = new ExpeditionEditViewModel()
			{
				Id = currentExpedition.Id,
				Name = currentExpedition.Name,
				StartDate = currentExpedition.StartDate,
				EndDate = currentExpedition.EndDate,
				Days = currentExpedition.Days,
				Enrolment = currentExpedition.Enrolment,
				Includes = currentExpedition.Includes,
				Excludes = currentExpedition.Excludes,
				Price = currentExpedition.Price,
				Program = currentExpedition.Program,
				Extras = currentExpedition.Extras,
				OrganiserId = currentExpedition.OrganiserId,
				RouteId = currentExpedition.RouteId,
				Routes = routes
			};

			return expedition;
		}

		public async Task<int> EditPostAsync(ExpeditionEditViewModel expeditionForm)
		{
			var expedition = await _repository.All<Expedition>()
				.Where(e => e.Id == expeditionForm.Id)
				.FirstOrDefaultAsync();

			expedition.Id = expeditionForm.Id;
			expedition.Name = expeditionForm.Name;
			expedition.StartDate = expeditionForm.StartDate;
			expedition.EndDate = expeditionForm.EndDate;
			expedition.Days = expeditionForm.Days;
			expedition.Enrolment = expeditionForm.Enrolment;
			expedition.Includes = expeditionForm.Includes;
			expedition.Excludes = expeditionForm.Excludes;
			expedition.Program = expeditionForm.Program;
			expedition.Price = expeditionForm.Price;
			expedition.Extras = expeditionForm.Extras;
			expedition.OrganiserId = expeditionForm.OrganiserId;
			expedition.RouteId = expeditionForm.RouteId;

			await _repository.SaveChangesAsync();
			return expedition.Id;
		}

		public async Task<ExpeditionRegisterViewModel> RegisterForExpeditionAsync(string userId, int expeditionId)
		{
			var user = await _repository.GetByIdAsync<IdentityUser>(userId);

			var expedition = await _repository.GetByIdAsync<Expedition>(expeditionId);

			bool isParticipantInExpedition = await _repository.AllReadOnly<ExpeditionParticipant>()
				.AnyAsync(ep => ep.ParticipantId == userId && ep.ExpeditionId == expeditionId);/*expedition.ExpeditionsParticipants.Any(ep => ep.ParticipantId == user.Id);*/
			if (isParticipantInExpedition)
			{
				return new ExpeditionRegisterViewModel()
				{
					Success = false,
					Message = "Вече сте записани за тази експедиция.",
				};
			}

			if (expedition.Enrolment < 1)
			{
				return new ExpeditionRegisterViewModel()
				{
					Success = false,
					Message = "Няма свободни места за експедицията.",
				};
			}

			var expeditionParticipant = new ExpeditionParticipant()
			{
				ExpeditionId = expeditionId,
				Expedition = expedition,
				ParticipantId = userId,
				Participant = user
			};

			expedition.Enrolment--;
			await _repository.AddAsync(expeditionParticipant);
			await _repository.SaveChangesAsync();

			return new ExpeditionRegisterViewModel()
			{
				Success = true,
				Message = "Успешно сте записани за експедицията!",
			};
		}

		public async Task<ExpeditionRegisterViewModel> UnregisterFromExpeditionAsync(string userId, int expeditionId)
		{
			var expeditionParticipant = await _repository.All<ExpeditionParticipant>()
				.FirstOrDefaultAsync(ep => ep.ParticipantId == userId && ep.ExpeditionId == expeditionId);

			if (expeditionParticipant == null)
			{
				return new ExpeditionRegisterViewModel()
				{
					Success = false,
					Message = "Вие не сте записани за тази експедиция.",
				};
			}

			var expedition = await _repository.GetByIdAsync<Expedition>(expeditionId);

			expedition.Enrolment++;
			_repository.Delete(expeditionParticipant);
			await _repository.SaveChangesAsync();


			return new ExpeditionRegisterViewModel()
			{
				Success = true,
				Message = "Успешно се отписахте от експедицията.",
			};
		}

		public async Task<IEnumerable<ExpeditionAllViewModel>> UserExpeditionsAsync(string userId)
		{
			return await _repository.AllReadOnly<ExpeditionParticipant>()
				.Include(ep => ep.Expedition)
				.Where(ep => ep.ParticipantId == userId)
				.Select(ep => new ExpeditionAllViewModel()
				{
					Id = ep.Expedition.Id,
					Name = ep.Expedition.Name,
					StartDate = ep.Expedition.StartDate.ToString(DateTimeFormat),
					EndDate = ep.Expedition.EndDate.ToString(DateTimeFormat),
					Price = ep.Expedition.Price.ToString(),
				})
				.ToListAsync();
		}
	}
}
