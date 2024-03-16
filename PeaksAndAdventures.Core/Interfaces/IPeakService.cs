using PeaksAndAdventures.Core.ViewModels.Peak;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IPeakService
{
    Task<IEnumerable<AllPeaksViewModel>> AllAsync();
    Task<bool> CheckPeakExistsByIdAsync (int peakId);

	Task<PeakFormViewModel> EditGetAsync(int peakId);
    Task<int> EditPostAsync(PeakFormViewModel peakForm);
}