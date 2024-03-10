using PeaksAndAdventures.Core.ViewModels.Peak;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IPeakService
{
    Task<IEnumerable<AllPeaksViewModel>> AllAsync();
}