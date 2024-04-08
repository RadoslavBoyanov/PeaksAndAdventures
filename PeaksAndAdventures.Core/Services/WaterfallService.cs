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

        public async Task<(IEnumerable<AllWaterfallsViewModel> Peaks, int TotalPages)> AllWaterfallsPaginationAsync(int page = 1, int pageSize = 3)
        {
            var allWaterfalls = await _repository
                .AllReadOnly<Waterfall>()
                .Select(w => new AllWaterfallsViewModel()
                {
                    Id = w.Id,
                    Name = w.Name,
                    ImageUrl = w.ImageUrl,
                })
                .ToListAsync();

			var waterfallsCount = allWaterfalls.Count();
			var totalPages = (int)Math.Ceiling((decimal)waterfallsCount / pageSize);
			var waterfallsPerPage = allWaterfalls
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			return (waterfallsPerPage, totalPages);
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

		public async Task<WaterfallDetailsViewModel> DetailsAsync(int id)
		{
			var waterfall = await _repository.AllReadOnly<Waterfall>()
				.Where(w => w.Id == id)
				.Include(w => w.Mountain)
				.Select(w => new WaterfallDetailsViewModel()
				{
					Id = w.Id,
					Name = w.Name,
					Description = w.Description,
					ImageUrl = w.ImageUrl,
					MountainName = w.Mountain.Name
				})
				.FirstOrDefaultAsync();

			return waterfall;
		}

		public async Task<WaterfallDeleteViewModel> DeleteGetAsync(int waterfallId)
		{
			var waterfall = await _repository.AllReadOnly<Waterfall>()
				.Where(w => w.Id == waterfallId)
				.Select(w => new WaterfallDeleteViewModel()
				{
					Id = w.Id,
					Name = w.Name,
					ImageUrl = w.ImageUrl,
				}).FirstOrDefaultAsync();

			return waterfall;
		}

		public async Task<int> DeleteConfirmedAsync(int waterfallId)
		{
			var waterfall = _repository.All<Waterfall>()
				.Include(w => w.Mountain)
				.FirstOrDefault(w => w.Id == waterfallId);

			if (waterfall.RoutesWaterfalls.Any())
			{
				foreach (var routeWaterfall in waterfall.RoutesWaterfalls)
				{
					_repository.Delete(routeWaterfall);
				}
			}

			await _repository.DeleteAsync<Waterfall>(waterfallId);
			await _repository.SaveChangesAsync();

			return waterfallId;
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
