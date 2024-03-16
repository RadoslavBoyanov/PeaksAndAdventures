using PeaksAndAdventures.Core.ViewModels.Peak;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IPeakService
{
    Task<IEnumerable<AllPeaksViewModel>> AllAsync();
    Task AddPeakToMountainAsync(PeakAddViewModel peakForm);
	Task<bool> CheckPeakExistsByIdAsync (int peakId);
	Task<bool> CheckPeakExistsByNameAsync(string peakName);
	Task<PeakEditViewModel> EditGetAsync(int peakId);
    Task<int> EditPostAsync(PeakEditViewModel peakForm);
}