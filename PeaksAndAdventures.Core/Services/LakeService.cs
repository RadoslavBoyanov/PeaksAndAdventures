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
    }
}
