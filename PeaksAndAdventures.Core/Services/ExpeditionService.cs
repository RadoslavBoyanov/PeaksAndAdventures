using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Expedition;
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
				Price = expedition.Price.ToString(),
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
	}
}
