using PeaksAndAdventures.Core.ViewModels.TourAgency;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface ITourAgencyService
	{
		Task AddTourAgencyAsync(TourAgencyAddViewModel tourAgencyForm);
	    Task<TourAgencyDetailsViewModel> DetailsAsync(int tourAgencyId);
		Task<TourAgencyEditViewModel> EditGetAsync(int tourAgencyId);
        Task<int> EditPostAsync(TourAgencyEditViewModel tourAgencyForm);
        Task<IEnumerable<TourAgencyGetViewModel>> GetAllTourAgenciesAsync();
        Task<TourAgencyGetViewModel?> GetTourAgencyByNameAsync(string tourAgencyName);
        Task<bool> CheckIfExistTourAgencyByName(string tourAgencyName);
    }
}
