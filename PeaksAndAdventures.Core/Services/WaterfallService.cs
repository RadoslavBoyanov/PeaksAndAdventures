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
                    Description = w.Description,
                    ImageUrl = w.ImageUrl,
                    MountainId = w.MountainId,
                    MountainName = w.Mountain.Name
				})
                .ToListAsync();
        }
    }
}
