using System.Collections;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Waterfall;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IMountainService
    { 
	    Task<IEnumerable<AllMountainsViewModel>> AllAsync();

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
