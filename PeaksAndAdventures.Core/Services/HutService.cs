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

        public async Task<HutEditViewModel> EditGetAsync(int hutId)
        {
	        var currentHut = await _repository.All<Hut>()
		        .FirstOrDefaultAsync(h => h.Id == hutId);

	        var hutForm = new HutEditViewModel()
	        {
		        Name = currentHut.Name,
		        Altitude = (int)currentHut.Altitude,
		        Description = currentHut.Description,
		        WorkTime = currentHut.WorkTime,
		        HasToilet = currentHut.HasToilet,
		        HasCanteen = currentHut.HasCanteen,
		        HasBathroom = currentHut.HasBathroom,
		        Camping = currentHut.Camping,
		        Phone = currentHut.Phone,
		        ImageUrl = currentHut.ImageUrl,
			};

	        return hutForm;
        }

        public async Task<int> EditPostAsync(HutEditViewModel hutForm)
        {
	        var hut = await _repository.All<Hut>()
		        .Where(h => h.Id == hutForm.Id)
		        .FirstOrDefaultAsync();

            hut.Name = hutForm.Name;
            hut.Description = hutForm.Description;
            hut.Altitude = hutForm.Altitude;
            hut.WorkTime = hutForm.WorkTime;
            hut.HasToilet = hutForm.HasToilet;
            hut.HasCanteen = hutForm.HasCanteen;
            hut.HasBathroom = hutForm.HasBathroom;
            hut.Places = hutForm.Places;
            hut.Camping = hutForm.Camping;
            hut.Phone = hutForm.Phone;
            hut.ImageUrl = hutForm.ImageUrl;

            await _repository.SaveChangesAsync();

            return hutForm.Id;
        }
    }
}
