using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Extensions;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;
using static PeaksAndAdventures.Extensions.EnumExtensions;

namespace PeaksAndAdventures.Core.Services
{
	public class HutService : IHutService
    {
        private readonly IRepository _repository;
        public HutService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<AllHutsViewModel>> AllAsync()
        {
            return await _repository
                .AllReadOnly<Hut>()
                .Select(h => new AllHutsViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Altitude = h.Altitude,
                    Description = h.Description,
                    WorkTime = h.WorkTime.GetDisplayName(),
                    HasToilet = h.HasToilet ? "да" : "не",
                    HasCanteen = h.HasCanteen ? "да" : "не",
                    HasBathroom = h.HasBathroom ? "да" : "не",
                    Camping = h.Camping.GetDisplayName(),
                    Phone = h.Phone,
                    ImageUrl = h.ImageUrl,
                    MountainId = h.MountainId,
                    MountainName = h.Mountain.Name
                })
                .ToListAsync();
        }

        public async Task AddHutToMountainAsync(AddHutViewModel hutForm)
        {
	        var hut = new Hut()
	        {
				Name = hutForm.Name,
				Altitude = hutForm.Altitude,
				Description = hutForm.Description,
				WorkTime = hutForm.WorkTime,
				HasToilet = hutForm.HasToilet,
				HasCanteen = hutForm.HasCanteen,
				HasBathroom = hutForm.HasBathroom,
				Camping = hutForm.Camping,
				Phone = hutForm.Phone,
				ImageUrl = hutForm.ImageUrl,
				MountainId = hutForm.MountainId,
			};

	        await _repository.AddAsync(hut);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> CheckHutExistsByIdAsync(int hutId)
        {
	        return await _repository.AllReadOnly<Hut>()
		        .AnyAsync(h => h.Id == hutId);
        }

        public async Task<bool> CheckHutExistsByNameAsync(string hutName)
        {
			return await _repository.AllReadOnly<Hut>()
				.AnyAsync(h => h.Name == hutName);
		}
    }
}
