using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
using PeaksAndAdventures.Extensions;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{

	public class MountainService : IMountainService
    {
        private readonly IRepository _repository;

        public MountainService(IRepository repository)
        {
            _repository = repository;
        }
         public async Task<IEnumerable<AllMountainsViewModel>> AllAsync()
         {
             return await _repository
                 .AllReadOnly<Mountain>()
                 .Select(m => new AllMountainsViewModel()
                 {
                     Id = m.Id,
                     Name = m.Name,
                     ImageUrls = m.ImageUrls
                 })
                 .ToListAsync();
         }

         public async Task<MountainDetailsViewModel> DetailsAsync(int id)
         {
	         var mountain = await _repository.GetByIdAsync<Mountain>(id);

	         var mountainDetails = new MountainDetailsViewModel()
	         {
				 Id = mountain.Id,
				 Name = mountain.Name,
				 Location = mountain.Location,
				 Climate = mountain.Climate,
				 Waters = mountain.Waters,
				 Flora = mountain.Flora,
				 Fauna = mountain.Fauna,
				 ImageUrls = mountain.ImageUrls
			 };

	         return mountainDetails;
         }

         public async Task<IEnumerable<GetAllMountainsViewModel>> GetAllMountains()
         {
	          return await _repository.AllReadOnly<Mountain>()
		         .Select(m => new GetAllMountainsViewModel()
		         {
					 Id = m.Id,
					 Name = m.Name,
		         }).ToListAsync();
         }

         public async Task<IEnumerable<AllPeaksViewModel>> GetAllPeaksAsync(int mountainId)
         {
	         return await _repository
		         .AllReadOnly<Peak>()
		         .Where(p => p.MountainId == mountainId)
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
			         MountainName = p.Mountain.Name
				 })
		         .ToListAsync();
         }

         public async Task<IEnumerable<AllHutsViewModel>> GetAllHutsAsync(int mountainId)
         {
	         return await _repository
		         .AllReadOnly<Hut>()
		         .Where(h => h.MountainId == mountainId)
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

         public async Task<IEnumerable<AllWaterfallsViewModel>> GetAllWaterfallsAsync(int mountainId)
         {
	         return await _repository
		         .AllReadOnly<Waterfall>()
		         .Where(w=>w.MountainId == mountainId)
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

         public async Task<IEnumerable<AllLakesViewModel>> GetAllLakesAsync(int mountainId)
         {
	         return await _repository
		         .AllReadOnly<Lake>()
		         .Where(l => l.MountainId == mountainId)
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

         public async Task<bool> CheckMountainExistsByNameAsync(string mountainName)
         {
			return await _repository.AllReadOnly<Mountain>()
				.AnyAsync(m => m.Name == mountainName);
		 }

         public async Task<bool> CheckMountainExistsByIdAsync(int mountainId)
         {
	         return await _repository.AllReadOnly<Mountain>()
		         .AnyAsync(m => m.Id == mountainId);
         }


         public async Task AddAsync(MountainFormViewModel mountainForm)
         {
	         Mountain mountain = new Mountain()
	         {
				 Name = mountainForm.Name,
				 Location = mountainForm.Location,
				 Climate = mountainForm.Climate,
				 Waters = mountainForm.Waters,
				 Flora = mountainForm.Flora,
				 Fauna = mountainForm.Fauna,
				 ImageUrls = mountainForm.ImageUrls
	         };

	         await _repository.AddAsync(mountain);
			 await _repository.SaveChangesAsync();
         }
         public async Task<MountainEditViewModel> EditGetAsync(int mountainId)
         {
	         var currentMountain = await _repository.All<Mountain>()
		         .FirstOrDefaultAsync(m => m.Id == mountainId);

	         var editMountain = new MountainEditViewModel()
	         {
				 Id = currentMountain.Id,
				 Name = currentMountain.Name,
				 Location = currentMountain.Location,
				 Climate = currentMountain.Climate,
				 Waters = currentMountain.Waters,
				 Flora = currentMountain.Flora,
				 Fauna = currentMountain.Fauna,
				 ImageUrls = currentMountain.ImageUrls
	         };

	         return editMountain;
         }

         public async Task<int> EditPostAsync(MountainEditViewModel mountainForm)
         {
	         var mountain = await _repository.All<Mountain>()
		         .Where(m => m.Id == mountainForm.Id)
				 .FirstOrDefaultAsync();

			 mountain.Name = mountainForm.Name;
			 mountain.Location = mountainForm.Location;
			 mountain.Climate = mountainForm.Climate;
			 mountain.Waters = mountain.Waters;
			 mountain.Flora = mountain.Flora;
			 mountain.ImageUrls = mountain.ImageUrls;

			 await _repository.SaveChangesAsync();

			 return mountain.Id;
         }

	}
}
