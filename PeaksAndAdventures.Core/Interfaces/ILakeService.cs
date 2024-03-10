using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;

namespace PeaksAndAdventures.Core.Interfaces;

public interface ILakeService
{
    Task<IEnumerable<AllLakesViewModel>> AllAsync();
}