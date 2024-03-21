using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IMountainGuideService
	{
		Task<IEnumerable<MountainGuideAllViewModel>> AllAsync();
		Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId);
		//Task<TourAgency> GetAgencyForGuideAsync(int mountainGuideId);
	}
}
