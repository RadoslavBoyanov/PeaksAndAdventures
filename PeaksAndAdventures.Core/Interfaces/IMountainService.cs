using PeaksAndAdventures.Core.ViewModels.Mountain;

namespace PeaksAndAdventures.Core.Interfaces
{
    public interface IMountainService
    {
        Task<IEnumerable<AllMountainsViewModel>> AllAsync();
    }
}
