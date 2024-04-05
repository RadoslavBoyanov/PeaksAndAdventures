using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
    public class WaterfallService : IWaterfallService
    {
        private readonly IRepository _repository;

        public WaterfallService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllWaterfallsViewModel>> AllAsync()
        {
            return await _repository
                .AllReadOnly<Waterfall>()
                .Select(w => new AllWaterfallsViewModel()
                {
                    Id = w.Id,
                    Name = w.Name,
                    ImageUrl = w.ImageUrl,
				})
                .ToListAsync();
        }

        public async Task<bool> CheckWaterfallExistsByNameAsync(string waterfallName)
        {
	        return await _repository.AllReadOnly<Waterfall>()
		        .AnyAsync(w => w.Name == waterfallName);
        }

        public async Task<bool> CheckWaterfallExistsByIdAsync(int waterfallId)
        {
	        return await _repository.AllReadOnly<Waterfall>()
		        .AnyAsync(w => w.Id == waterfallId);
        }

        public async Task AddWaterfallToMountain(WaterfallAddViewModel waterfallAdd)
        {
	        var waterfall = new Waterfall()
	        {
                Name = waterfallAdd.Name,
                Description = waterfallAdd.Description,
                ImageUrl = waterfallAdd.ImageUrl,
                MountainId = waterfallAdd.MountainId
	        };

	        await _repository.AddAsync(waterfall);
	        await _repository.SaveChangesAsync();
        }

        public async Task<WaterfallEditViewModel> EditGetAsync(int waterfallId)
        {
	        var currentWaterfall = await _repository.All<Waterfall>()
		        .FirstOrDefaultAsync(w => w.Id == waterfallId);

	        var waterfallForm = new WaterfallEditViewModel()
	        {
                Id = currentWaterfall.Id,
                Name = currentWaterfall.Name,
                Description = currentWaterfall.Description,
                ImageUrl = currentWaterfall.ImageUrl,
	        };

	        return waterfallForm;
        }

        public async Task<int> EditPostAsync(WaterfallEditViewModel waterfallForm)
        {
	        var waterfall = await _repository.All<Waterfall>()
		        .Where(w => w.Id == waterfallForm.Id)
		        .FirstOrDefaultAsync();

            waterfall.Name = waterfallForm.Name;
            waterfall.Description = waterfallForm.Description;
            waterfall.ImageUrl = waterfallForm.ImageUrl;

            await _repository.SaveChangesAsync();

            return waterfall.Id;
        }
    }
}
