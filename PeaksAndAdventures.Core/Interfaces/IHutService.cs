using PeaksAndAdventures.Core.Models.QueryModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IHutService
{
    Task<IEnumerable<AllHutsViewModel>> AllAsync();
    HutQueryServiceModel All(string? workTime = null, string? camping = null,
        string? searchTerm = null, string? mountainSort = null,
        int currentPage = 1, int hutPerPage = 3);
    Task AddHutToMountainAsync(AddHutViewModel hutForm);
    Task<bool> CheckHutExistsByIdAsync(int hutId);
    Task<bool> CheckHutExistsByNameAsync(string hutName);
    Task<HutDetailsViewModel> DetailsAsync(int hutId);
    Task<HutDeleteViewModel> DeleteGetAsync(int hutId);
    Task<int> DeleteConfirmedAsync(int hutId);
    Task<HutEditViewModel> EditGetAsync(int hutId);
    Task<int> EditPostAsync(HutEditViewModel hutForm);
}