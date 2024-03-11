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

        public Task<IEnumerable<AllLakesViewModel>> GetAllLakesAsync(int mountainId);
        public Task<IEnumerable<AllPeaksViewModel>> GetAllPeaksAsync(int mountainId);
        public Task<IEnumerable<AllHutsViewModel>> GetAllHutsAsync(int mountainId);

        public Task<IEnumerable<AllWaterfallsViewModel>> GetAllWaterfallsAsync(int mountainId);

    }
}
