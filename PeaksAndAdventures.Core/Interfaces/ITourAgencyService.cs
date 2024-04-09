using PeaksAndAdventures.Core.Models.ViewModels.Expedition;
using PeaksAndAdventures.Core.Models.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.Models.ViewModels.TourAgency;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface ITourAgencyService
	{
		Task AddTourAgencyAsync(TourAgencyAddViewModel tourAgencyForm);
		Task<IEnumerable<MountainGuideAllViewModel>> AllMountainGuideInAgencyAsync(int tourAgencyId);
	    Task<TourAgencyDetailsViewModel> DetailsAsync(int tourAgencyId);
		Task<TourAgencyDeleteViewModel> DeleteGetAsync(int tourAgencyId);
		Task<string> DeleteConfirmedAsync(int tourAgencyId);
		Task<TourAgencyEditViewModel> EditGetAsync(int tourAgencyId);
        Task<int> EditPostAsync(TourAgencyEditViewModel tourAgencyForm);
        Task<IEnumerable<TourAgencyGetViewModel>> GetAllTourAgenciesAsync();
        Task<TourAgencyGetViewModel?> GetTourAgencyByNameAsync(string tourAgencyName);
		Task<IEnumerable<ExpeditionAllViewModel>> GetExpeditionsInAgencyAsync(int tourAgencyId);
        Task<bool> CheckIfExistTourAgencyByName(string tourAgencyName);
		Task<bool> CheckIfExistTourAgencyById(int tourAgencyId);
    }
}
