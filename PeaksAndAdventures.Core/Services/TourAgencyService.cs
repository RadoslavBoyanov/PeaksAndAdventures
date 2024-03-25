using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.TourAgency;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
	public class TourAgencyService : ITourAgencyService
	{
		private readonly IRepository _repository;

		public TourAgencyService(IRepository repository)
		{
			_repository = repository;
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
			};

			return tourAgencyDetails;
		}

		public async Task<TourAgencyEditViewModel> EditGetAsync(int tourAgencyId)
		{
			var currentTourAgency = await _repository.All<TourAgency>()
				.FirstOrDefaultAsync(ta => ta.Id == tourAgencyId);

			var tourAgency = new TourAgencyEditViewModel()
			{
                Id = currentTourAgency.Id,
                Name = currentTourAgency.Name,
                Description = currentTourAgency.Description,
                Email = currentTourAgency.Description,
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
                    Rating = ta.Rating.ToString()
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



        public async Task<bool> CheckIfExistTourAgencyByName(string tourAgencyName)
        {
            return await _repository.AllReadOnly<TourAgency>()
                .AnyAsync(ta => ta.Name == tourAgencyName);
        }
    }
}
