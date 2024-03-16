using PeaksAndAdventures.Core.ViewModels.Waterfall;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IWaterfallService
{
    Task<IEnumerable<AllWaterfallsViewModel>> AllAsync();
    Task<bool> CheckWaterfallExistsByNameAsync(string waterfallName);
    Task<bool> CheckWaterfallExistsByIdAsync(int waterfallId);
	Task AddWaterfallToMountain(WaterfallAddViewModel waterfallAdd);
	Task<WaterfallEditViewModel> EditGetAsync(int waterfallId);
	Task<int> EditPostAsync(WaterfallEditViewModel waterfallForm);
}