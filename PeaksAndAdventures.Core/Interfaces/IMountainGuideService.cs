using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IMountainGuideService
	{
		Task AddAsync(MountainGuideAddViewModel mountainGuideForm);
		Task<IEnumerable<MountainGuideAllViewModel>> AllAsync();
		Task<bool> AddRouteToMountainGuideAsync(int mountainGuideId, int routeId, string ownerId);
		Task<bool> CheckIfExistMountainGuideByIdAsync(int mountainGuideId); 
		Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId);
		Task<MountainGuideDeleteViewModel> DeleteGetAsync(int mountainGuideId);
		Task<int> DeleteConfirmedAsync(int mountainGuideId);
		Task<MountainGuideEditViewModel> EditGetAsync(int mountainGuideId);
		Task<int> EditPostAsync(MountainGuideEditViewModel mountainGuideEdit);
		Task<MountainGuideAddRouteViewModel> GetMountainGuideAddRouteViewModelAsync(int mountainGuideId);
	}
}
