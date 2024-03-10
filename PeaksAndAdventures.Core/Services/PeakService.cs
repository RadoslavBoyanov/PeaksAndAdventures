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

        public PeakService(IRepository repository)
        {
            _repository = repository;
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
                })
                .ToListAsync();
        }
    }
}
