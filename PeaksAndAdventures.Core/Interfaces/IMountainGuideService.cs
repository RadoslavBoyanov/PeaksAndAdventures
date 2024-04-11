using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using PeaksAndAdventures.Core.Models.ViewModels.MountainGuide;
using PeaksAndAdventures.Core.Models.ViewModels.Route;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IMountainGuideService
	{
		Task AddAsync(MountainGuideAddViewModel mountainGuideForm);
		Task<IEnumerable<MountainGuideAllViewModel>> AllAsync();
		Task<bool> AddRouteToMountainGuideAsync(int mountainGuideId, int routeId, string ownerId);
		Task<bool> AddMountainToMountainGuideAsync(int id, int mountainId, string ownerId);
		Task<bool> CheckIfExistMountainGuideByIdAsync(int mountainGuideId); 
		Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId);
		Task<MountainGuideDeleteViewModel> DeleteGetAsync(int mountainGuideId);
		Task<int> DeleteConfirmedAsync(int mountainGuideId);
		Task<MountainGuideEditViewModel> EditGetAsync(int mountainGuideId);
		Task<int> EditPostAsync(MountainGuideEditViewModel mountainGuideEdit);
		Task<MountainGuideAddRouteViewModel> GetMountainGuideAddRouteAsync(int mountainGuideId);
		Task<MountainGuideAddMountainViewModel> GetMountainGuideAddMountainAsync(int mountainGuideId);
		Task<IEnumerable<GetAllMountainsViewModel>> GetAllMountainsAsync(int mountainGuideId);
		Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync(int mountainGuideId);
	}
}
