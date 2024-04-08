using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Peak;

namespace PeaksAndAdventures.Core.Interfaces;

public interface ILakeService
{
	Task<IEnumerable<AllLakesViewModel>> AllAsync();
	Task<(IEnumerable<AllLakesViewModel> Lakes, int TotalPages)> AllPaginationAsync(int page = 1, int pageSize = 3);
	Task AddLakeToMountainAsync(LakeAddViewModel lakeForm);
	Task<bool> CheckLakeExistsByNameAsync(string lakeName);
	Task<LakeDetailsViewModel> DetailsAsync(int lakeId);
	Task<LakeDeleteViewModel> DeleteGetAsync(int lakeId);
	Task<int> DeleteConfirmedAsync(int lakeId);
	Task<LakeEditViewModel> EditGetAsync(int lakeId);
	Task<int> EditPostAsync(LakeEditViewModel lakeForm);
	Task<bool> CheckLakeExistsByIdAsync(int lakeId);
}