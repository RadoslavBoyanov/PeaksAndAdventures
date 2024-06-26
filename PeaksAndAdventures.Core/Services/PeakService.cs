﻿using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using PeaksAndAdventures.Core.Models.ViewModels.Route;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
    public class PeakService : IPeakService
    {
        private readonly IRepository _repository;

        public PeakService(IRepository repository)
        {
	        _repository = repository;
        }


		public async Task<(IEnumerable<AllPeaksViewModel> Peaks, int TotalPages)> AllPaginationAsync(int page = 1, int pageSize = 10)
		{
			var allPeaks = await _repository
				.AllReadOnly<Peak>()
				.Select(p => new AllPeaksViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Altitude = p.Altitude,
					ImageUrl = p.ImageUrl,
					MountainId = p.MountainId,
					MountainName = p.Mountain.Name
				})
				.ToListAsync();

			var peaksCount = allPeaks.Count();
			var totalPages = (int)Math.Ceiling((decimal)peaksCount / pageSize);
			var peaksPerPage = allPeaks
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			return (peaksPerPage, totalPages);
		}

		public async Task<IEnumerable<AllPeaksViewModel>> AllAsync()
		{
			var allPeaks = await _repository
				.AllReadOnly<Peak>()
				.Select(p => new AllPeaksViewModel()
				{
					Id = p.Id,
					Name = p.Name,
					Altitude = p.Altitude,
					ImageUrl = p.ImageUrl,
					MountainId = p.MountainId,
					MountainName = p.Mountain.Name
				})
				.ToListAsync();

			return allPeaks;
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

        public async Task<bool> CheckPeakExistsByNameAsync(string mountain)
        {
	        return await _repository.AllReadOnly<Peak>()
		        .AnyAsync(p => p.Name == mountain);
        }

        public async Task<PeakDetailsViewModel> DetailsAsync(int peakId)
        {
	        var peak = await _repository.AllReadOnly<Peak>()
		        .Where(p => p.Id == peakId)
		        .Include(p => p.Mountain)
		        .Select(p => new PeakDetailsViewModel()
		        {
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Altitude = p.Altitude,
					Partition = p.Partition,
					SpecificLocation = p.SpecificLocation,
					ImageUrl = p.ImageUrl,
					MountainId = p.MountainId,
					MountainName = p.Mountain.Name
		        })
		        .FirstOrDefaultAsync();

			return peak;
        }

        public async Task<PeakDeleteViewModel> DeleteGetAsync(int peakId)
        {
	        var peak = await _repository.All<Peak>()
		        .Where(p => p.Id == peakId)
		        .Select(p => new PeakDeleteViewModel()
		        {
			        Id = p.Id,
                    Name = p.Name,
                    MountainName = p.Mountain.Name
		        }).FirstOrDefaultAsync();
            
			return peak;
        }

        public async Task<int> DeleteConfirmedAsync(int peakId)
        {
	        var peak = await _repository.All<Peak>()
                .Include(p => p.RoutesPeaks)
		        .FirstOrDefaultAsync(p => p.Id == peakId);

	        if (peak.RoutesPeaks.Any())
	        {
		        foreach (var routePeak in peak.RoutesPeaks)
		        {
			        _repository.Delete(routePeak);
		        }
	        }

			await _repository.DeleteAsync<Peak>(peakId);
			await _repository.SaveChangesAsync();

			return peakId;
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
            peak.SpecificLocation = peakForm.SpecificLocation;
            peak.ImageUrl = peakForm.ImageUrl;

            await _repository.SaveChangesAsync();

            return peak.Id;
        }

        public async Task<IEnumerable<GetAllRoutesViewModel>> GetRoutesToPeakAsync(int peakId)
        {
	        return await _repository.AllReadOnly<RoutePeak>()
		        .Where(rp => rp.PeakId == peakId)
		        .Select(rp => new GetAllRoutesViewModel()
		        {
			        Id = rp.RouteId,
			        Name = rp.Route.Name,
			        ImageUrl = rp.Route.ImageUrl
		        })
		        .ToListAsync();
        }
    }
}
