using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
    public class LakeService : ILakeService
    {
        private readonly IRepository _repository;

        public LakeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllLakesViewModel>> AllAsync()
        {
            return await _repository
                .AllReadOnly<Lake>()
                .Select(l => new AllLakesViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    ImageUrl = l.ImageUrl,
				})
                .ToListAsync();
        }

        public async Task AddLakeToMountainAsync(LakeAddViewModel lakeForm)
        {
	        var lake = new Lake()
	        {
                Name = lakeForm.Name,
                Description = lakeForm.Description,
                ImageUrl = lakeForm.ImageUrl,
                MountainId = lakeForm.MountainId,
	        };

			await _repository.AddAsync(lake);
			await _repository.SaveChangesAsync();
		}

        public async Task<bool> CheckLakeExistsByNameAsync(string lakeName)
        {
	        return await _repository.AllReadOnly<Lake>()
		        .AnyAsync(l => l.Name == lakeName);
        }

        public async Task<LakeDetailsViewModel> DetailsAsync(int lakeId)
        {
	        var lake = await _repository.AllReadOnly<Lake>()
		        .Include(l=> l.Mountain)
		        .FirstOrDefaultAsync(l=>l.Id == lakeId);

	        var lakeDetails = new LakeDetailsViewModel()
	        {
		        Id = lake.Id,
		        Name = lake.Name,
		        Description = lake.Description,
		        ImageUrl = lake.ImageUrl,
		        MountainName = lake.Mountain.Name,
	        };

            return lakeDetails;
        }

        public async Task<LakeDeleteViewModel> DeleteGetAsync(int lakeId)
        {
	        var lake = await _repository.AllReadOnly<Lake>()
		        .Include(l => l.Mountain)
		        .Where(l => l.Id == lakeId)
		        .Select(l => new LakeDeleteViewModel()
		        {
                    Id = l.Id,
                    Name = l.Name,
                    ImageUrl = l.ImageUrl,
                    MountainName = l.Mountain.Name,
		        })
		        .FirstOrDefaultAsync();

            return lake;
        }

        public async Task<int> DeleteConfirmedAsync(int lakeId)
        {
	        var lake = await _repository.All<Lake>()
		        .Include(l => l.RoutesLakes)
		        .FirstOrDefaultAsync(l => l.Id == lakeId);

	        if (lake.RoutesLakes.Any())
	        {
		        foreach (var lakeRoute in lake.RoutesLakes)
		        {
			        _repository.Delete(lakeRoute);
		        }
	        }

	        await _repository.DeleteAsync<Lake>(lakeId);
            await _repository.SaveChangesAsync();

            return lakeId;
        }

        public async Task<LakeEditViewModel> EditGetAsync(int id)
        {
	        var currentLake = await _repository.All<Lake>()
		        .FirstOrDefaultAsync(l => l.Id == id);

	        var lakeForm = new LakeEditViewModel()
	        {
                Id = currentLake.Id,
                Name = currentLake.Name,
                Description = currentLake.Description,
                ImageUrl = currentLake.ImageUrl,
	        };

	        return lakeForm;
        }

        public async Task<int> EditPostAsync(LakeEditViewModel lakeEdit)
        {
	        var lake = await _repository.All<Lake>()
		        .Where(l => l.Id == lakeEdit.Id)
		        .FirstOrDefaultAsync();

	        lake.Name = lakeEdit.Name;
			lake.Description = lakeEdit.Description;
            lake.ImageUrl = lakeEdit.ImageUrl;

            await _repository.SaveChangesAsync();

            return lake.Id;
        }

        public async Task<bool> CheckLakeExistsByIdAsync(int lakeId)
        {
	        return await _repository.AllReadOnly<Lake>()
		        .AnyAsync(l => l.Id == lakeId);
        }
    }
}
