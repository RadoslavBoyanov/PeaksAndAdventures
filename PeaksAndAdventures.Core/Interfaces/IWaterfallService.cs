using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IWaterfallService
{
    Task<IEnumerable<AllWaterfallsViewModel>> AllAsync();
    Task<(IEnumerable<AllWaterfallsViewModel> Peaks, int TotalPages)> AllWaterfallsPaginationAsync(int page = 1, int pageSize = 3);
    Task<bool> CheckWaterfallExistsByNameAsync(string waterfallName);
    Task<bool> CheckWaterfallExistsByIdAsync(int waterfallId);
	Task AddWaterfallToMountain(WaterfallAddViewModel waterfallAdd);
	Task<WaterfallDetailsViewModel> DetailsAsync(int id);
	Task<WaterfallDeleteViewModel> DeleteGetAsync(int waterfallId);
	Task<int> DeleteConfirmedAsync(int waterfallId);
	Task<WaterfallEditViewModel> EditGetAsync(int waterfallId);
	Task<int> EditPostAsync(WaterfallEditViewModel waterfallForm);
}