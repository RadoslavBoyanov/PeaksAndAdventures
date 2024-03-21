using PeaksAndAdventures.Core.ViewModels.MountainGuide;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IMountainGuideService
	{
		Task<IEnumerable<MountainGuideAllViewModel>> AllAsync();
	}
}
