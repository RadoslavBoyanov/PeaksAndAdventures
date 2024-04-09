using PeaksAndAdventures.Core.Models.ViewModels.Mountain;

namespace PeaksAndAdventures.Core.Models.ViewModels.MountainGuide
{
    /// <summary>
    /// view model for add mountain to mountain guide
    /// </summary>
    public class MountainGuideAddMountainViewModel
    {
        public int Id { get; set; }

        public string OwnerId { get; set; } = null!;

        public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();
    }
}
