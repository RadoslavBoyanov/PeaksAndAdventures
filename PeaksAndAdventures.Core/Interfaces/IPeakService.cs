using PeaksAndAdventures.Core.Models.ViewModels.Peak;

namespace PeaksAndAdventures.Core.Interfaces;

public interface IPeakService
{
	Task<(IEnumerable<AllPeaksViewModel> Peaks, int TotalPages)> AllPaginationAsync(int page = 1, int pageSize = 10);
	Task<IEnumerable<AllPeaksViewModel>> AllAsync();
	Task AddPeakToMountainAsync(PeakAddViewModel peakForm);
	Task<bool> CheckPeakExistsByIdAsync (int peakId);
	Task<bool> CheckPeakExistsByNameAsync(string peakName);
	Task<PeakDetailsViewModel> DetailsAsync(int peakId);
	Task<PeakDeleteViewModel> DeleteGetAsync(int peakId);
	Task<int> DeleteConfirmedAsync(int peakId);
	Task<PeakEditViewModel> EditGetAsync(int peakId);
    Task<int> EditPostAsync(PeakEditViewModel peakForm);
}