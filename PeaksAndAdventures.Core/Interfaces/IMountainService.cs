using System.Collections;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Lake;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IMountainService
    { 
	    Task<(IEnumerable<AllMountainsViewModel> Mountains, int TotalPages)> AllMountainsPaginationAsync(int page = 1, int pageSize = 6);
		Task<MountainDetailsViewModel> DetailsAsync(int mountainId);
		Task<IEnumerable<GetAllMountainsViewModel>> GetAllMountains();
		Task<IEnumerable<AllLakesViewModel>> GetAllLakesAsync(int mountainId);
        Task<IEnumerable<AllPeaksViewModel>> GetAllPeaksAsync(int mountainId);
        Task<IEnumerable<AllHutsViewModel>> GetAllHutsAsync(int mountainId);
        Task<IEnumerable<AllWaterfallsViewModel>> GetAllWaterfallsAsync(int mountainId);
        Task AddAsync (MountainFormViewModel mountainForm); 
        Task<bool> CheckMountainExistsByNameAsync(string mountainName);
        Task<bool> CheckMountainExistsByIdAsync(int mountainId);
        Task<MountainEditViewModel> EditGetAsync (int mountainId);
        Task<int> EditPostAsync(MountainEditViewModel mountainForm);
    }
}
