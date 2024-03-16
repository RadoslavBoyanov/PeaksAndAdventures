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
                    Description = l.Description,
                    ImageUrl = l.ImageUrl,
                    MountainId = l.MountainId,
                    MountainName = l.Mountain.Name
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
