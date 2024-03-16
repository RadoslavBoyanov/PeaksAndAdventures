using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
    public class PeakService : IPeakService
    {
        private readonly IRepository _repository;
        private readonly IMountainService _mountainService;

        public PeakService(IRepository repository, IMountainService mountainService)
        {
	        _repository = repository;
	        _mountainService = mountainService;
        }

        public async Task<IEnumerable<AllPeaksViewModel>> AllAsync()
        {
            return await _repository
                .AllReadOnly<Peak>()
                .Select(p => new AllPeaksViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Partition = p.Partition,
                    SpecificLocation = p.SpecificLocation,
                    Altitude = p.Altitude,
                    ImageUrl = p.ImageUrl,
                    MountainId = p.MountainId,
                    MountainName = p.Mountain.Name
				})
                .ToListAsync();
        }

        public async Task AddPeakToMountainAsync(PeakAddViewModel peakForm)
        {
	        var peak = new Peak()
	        {
                Name = peakForm.Name,
                Description = peakForm.Description,
                Partition = peakForm.Partition,
                SpecificLocation = peakForm.SpecificLocation,
                Altitude = peakForm.Altitude,
                ImageUrl = peakForm.ImageUrl,
                MountainId = peakForm.MountainId
	        };

			await _repository.AddAsync(peak);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> CheckPeakExistsByIdAsync(int peakId)
        {
			return await _repository.AllReadOnly<Peak>()
				.AnyAsync(m => m.Id == peakId);
		}

        public async Task<PeakEditViewModel> EditGetAsync(int peakId)
        {
	        var currentPeak = await _repository.All<Peak>()
		        .FirstOrDefaultAsync(p => p.Id == peakId);

	        var peakForm = new PeakEditViewModel()
	        {
                Id = currentPeak.Id,
                Name = currentPeak.Name,
                Description = currentPeak.Description,
                Altitude = currentPeak.Altitude,
                Partition = currentPeak.Partition,
                SpecificLocation = currentPeak.SpecificLocation,
                ImageUrl = currentPeak.ImageUrl,
	        };

            return peakForm;
        }

        public async Task<int> EditPostAsync(PeakEditViewModel peakForm)
        {
	        var peak = await _repository.All<Peak>()
		        .Where(p => p.Id == peakForm.Id)
		        .FirstOrDefaultAsync();

            peak.Name = peakForm.Name;
            peak.Description = peakForm.Description;
            peak.Altitude = peakForm.Altitude;
            peak.Partition = peakForm.Partition;
            peak.SpecificLocation = peak.SpecificLocation;
            peak.ImageUrl = peakForm.ImageUrl;

            await _repository.SaveChangesAsync();

            return peak.Id;
        }
    }
}
