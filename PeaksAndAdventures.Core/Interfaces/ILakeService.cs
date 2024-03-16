using PeaksAndAdventures.Core.ViewModels.Lake;

namespace PeaksAndAdventures.Core.Interfaces;

public interface ILakeService
{
	Task<IEnumerable<AllLakesViewModel>> AllAsync();
	Task AddLakeToMountainAsync(LakeAddViewModel lakeForm);
	Task<bool> CheckLakeExistsByNameAsync(string lakeName);
	Task<LakeEditViewModel> EditGetAsync(int lakeId);
	Task<int> EditPostAsync(LakeEditViewModel lakeForm);
	Task<bool> CheckLakeExistsByIdAsync(int lakeId);
}