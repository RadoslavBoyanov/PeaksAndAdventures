using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Expedition;
using PeaksAndAdventures.Core.Models.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.Models.ViewModels.TourAgency;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;
using static PeaksAndAdventures.Common.EntityValidations.ExpeditionValidation;
using static PeaksAndAdventures.Common.ErrorMessages;
using static PeaksAndAdventures.Common.SuccessMessages;

namespace PeaksAndAdventures.Core.Services
{
    public class TourAgencyService : ITourAgencyService
	{
		private readonly IRepository _repository;

		public TourAgencyService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task AddTourAgencyAsync(TourAgencyAddViewModel tourAgencyForm)
		{
			var owner = await _repository.GetByIdAsync<IdentityUser>(tourAgencyForm.OwnerId);

			var tourAgency = new TourAgency()
			{
				Name = tourAgencyForm.Name,
				Description = tourAgencyForm.Description,
				Email = tourAgencyForm.Email,
				Phone = tourAgencyForm.Phone,
				OwnerId = tourAgencyForm.OwnerId,
				Owner = owner
			};

			await _repository.AddAsync(tourAgency);
			await _repository.SaveChangesAsync();
		}

		public async Task<IEnumerable<MountainGuideAllViewModel>> AllMountainGuideInAgencyAsync(int tourAgencyId)
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.Where(mg => mg.TourAgencyId == tourAgencyId)
				.Select(mg => new MountainGuideAllViewModel()
				{
					Id = mg.Id,
					FirstName = mg.FirstName,
					LastName = mg.LastName,
					ImageUrl = mg.ImageUrl
				})
				.ToListAsync();
		}

		public async  Task<TourAgencyDetailsViewModel> DetailsAsync(int tourAgencyId)
		{
			var tourAgency = await _repository.GetByIdAsync<TourAgency>(tourAgencyId);

			var tourAgencyDetails = new TourAgencyDetailsViewModel()
			{
				Id = tourAgency.Id,
				Name = tourAgency.Name,
				Description = tourAgency.Description,
				Email = tourAgency.Email,
				Phone = tourAgency.Phone,
				OwnerId = tourAgency.OwnerId,
			};

			return tourAgencyDetails;
		}

		public async Task<TourAgencyDeleteViewModel> DeleteGetAsync(int tourAgencyId)
		{
			var agency = await _repository.AllReadOnly<TourAgency>()
				.Where(ta => ta.Id == tourAgencyId)
				.Select(ta => new TourAgencyDeleteViewModel()
				{
					Id = ta.Id,
					Name = ta.Name,
					Email = ta.Email,
					Phone = ta.Phone,
					OwnerId = ta.OwnerId
				})
				.FirstOrDefaultAsync();

			return agency;
		}

		public async Task<string> DeleteConfirmedAsync(int tourAgencyId)
		{
			var tourAgency = await _repository.All<TourAgency>()
				.Include(ta => ta.MountainGuides)
				.Include(ta => ta.Expeditions)
				.FirstOrDefaultAsync(ta => ta.Id == tourAgencyId);

			if (tourAgency.MountainGuides.Any())
			{
				foreach (var guide in tourAgency.MountainGuides)
				{
					guide.TourAgencyId = null;
					guide.TourAgency = null;
				}
			}

			if (tourAgency.Expeditions.Any())
			{
				foreach (var expedition in tourAgency.Expeditions)
				{
					expedition.ExpeditionsParticipants = await  _repository.AllReadOnly<ExpeditionParticipant>()
						.Where(ep => ep.ExpeditionId == expedition.Id)
						.ToListAsync();

					if (expedition.ExpeditionsParticipants.Any())
					{
						return CantDeleteTourAgencyBecauseOfExpeditionParticipant;
					}
					else
					{
						_repository.Delete(expedition);
					}
				}
			}

			await _repository.DeleteAsync<TourAgency>(tourAgencyId);
			await _repository.SaveChangesAsync();

			return SuccesscfullyDeletedTourAgency;
		}

		public async Task<TourAgencyEditViewModel> EditGetAsync(int tourAgencyId)
		{
			var currentTourAgency = await _repository.AllReadOnly<TourAgency>()
				.FirstOrDefaultAsync(ta => ta.Id == tourAgencyId);

			var tourAgency = new TourAgencyEditViewModel()
			{
                Id = currentTourAgency.Id,
                Name = currentTourAgency.Name,
                Description = currentTourAgency.Description,
                Email = currentTourAgency.Email,
                OwnerId = currentTourAgency.OwnerId,
                Phone = currentTourAgency.Phone,
			};

			return tourAgency;
		}

		public async Task<int> EditPostAsync(TourAgencyEditViewModel tourAgencyForm)
		{
			var tourAgency = await _repository.All<TourAgency>()
				.Where(ta => ta.Id == tourAgencyForm.Id)
				.FirstOrDefaultAsync();

            tourAgency.Name = tourAgencyForm.Name;
            tourAgency.Description = tourAgencyForm.Description;
            tourAgency.Email = tourAgencyForm.Email;
            tourAgency.Phone = tourAgencyForm.Phone;

            await _repository.SaveChangesAsync();
            return tourAgency.Id;
		}

		public async Task<IEnumerable<TourAgencyGetViewModel>> GetAllTourAgenciesAsync()
        {
            return await _repository.AllReadOnly<TourAgency>()
                .Select(ta => new TourAgencyGetViewModel()
                {
                    Id = ta.Id,
                    Name = ta.Name,
                })
                .ToListAsync();
        }

        public async Task<TourAgencyGetViewModel?> GetTourAgencyByNameAsync(string tourAgencyName)
        {
            return await _repository.AllReadOnly<TourAgency>()
                .Where(ta => ta.Name == tourAgencyName)
                .Select(ta => new TourAgencyGetViewModel()
                {
                    Id = ta.Id,
                    Name = ta.Name,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExpeditionAllViewModel>> GetExpeditionsInAgencyAsync(int tourAgencyId)
        {
	        return await _repository.AllReadOnly<Expedition>()
		        .Where(e => e.TourAgencyId == tourAgencyId)
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


        public async Task<bool> CheckIfExistTourAgencyByName(string tourAgencyName)
        {
            return await _repository.AllReadOnly<TourAgency>()
                .AnyAsync(ta => ta.Name == tourAgencyName);
        }

        public Task<bool> CheckIfExistTourAgencyById(int tourAgencyId)
        {
	        return _repository.AllReadOnly<TourAgency>()
		        .AnyAsync(ta => ta.Id == tourAgencyId);
        }
	}
}
