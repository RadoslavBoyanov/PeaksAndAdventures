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
