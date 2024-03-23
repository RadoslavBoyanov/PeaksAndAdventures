using PeaksAndAdventures.Core.ViewModels.TourAgency;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface ITourAgencyService
    {
        Task<IEnumerable<TourAgencyGetViewModel>> GetAllTourAgenciesAsync();
        Task<TourAgencyGetViewModel?> GetTourAgencyByNameAsync(string tourAgencyName);
        Task<bool> CheckIfExistTourAgencyByName(string tourAgencyName);
    }
}
