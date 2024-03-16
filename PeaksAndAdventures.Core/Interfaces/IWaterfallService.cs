using PeaksAndAdventures.Core.ViewModels.Waterfall;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IWaterfallService
{
    Task<IEnumerable<AllWaterfallsViewModel>> AllAsync();
    Task<bool> CheckWaterfallExistsByNameAsync(string waterfallName);
	Task AddWaterfallToMountain(WaterfallAddViewModel waterfallAdd);
}