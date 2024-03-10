using PeaksAndAdventures.Core.ViewModels.Hut;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IHutService
{
    Task<IEnumerable<AllHutsViewModel>> AllAsync();
}