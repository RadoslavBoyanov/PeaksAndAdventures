using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Expedition;
using PeaksAndAdventures.Core.ViewModels.Route;
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
			var expedition = await _repository.GetByIdAsync<Expedition>(expeditionId);

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
	}
}
