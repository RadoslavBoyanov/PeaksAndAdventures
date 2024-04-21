using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Lake;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using PeaksAndAdventures.Core.Models.ViewModels.Peak;
using PeaksAndAdventures.Core.Models.ViewModels.Route;
using PeaksAndAdventures.Core.Models.ViewModels.Waterfall;
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

         public async Task<(IEnumerable<AllMountainsViewModel> Mountains, int TotalPages)> AllMountainsPaginationAsync(int page = 1, int pageSize = 6)
         {
	         var allMountains = await _repository
		         .AllReadOnly<Mountain>()
		         .Select(m => new AllMountainsViewModel()
		         {
			         Id = m.Id,
			         Name = m.Name,
			         ImageUrls = m.ImageUrls
		         })
		         .ToListAsync();

			 var mountainsCount = allMountains.Count();
			 var totalPages = (int)Math.Ceiling((decimal)mountainsCount / pageSize);
			 var mountainsPerPage = allMountains
				 .Skip((page - 1) * pageSize)
				 .Take(pageSize)
				 .ToList();

			 return (mountainsPerPage, totalPages);
		}

         public async Task<MountainDetailsViewModel> DetailsAsync(int id)
         {
	         var mountain = await _repository.GetByIdAsync<Mountain>(id);

	         if (mountain is null)
	         {
		         return null;
	         }

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
			         ImageUrl = h.ImageUrl,
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
			         ImageUrl = w.ImageUrl,
				 })
		         .ToListAsync();
         }

         public async Task<IEnumerable<GetAllRoutesViewModel>> GetAllRoutesAsync(int mountainId)
         {
	         return await _repository
		         .AllReadOnly<Route>()
		         .Where(r => r.MountainId == mountainId)
		         .Select(r => new GetAllRoutesViewModel()
		         {
			         Id = r.Id,
			         Name = r.Name,
			         ImageUrl = r.ImageUrl,
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
			         ImageUrl = l.ImageUrl,
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
			 mountain.Waters = mountainForm.Waters;
			 mountain.Flora = mountainForm.Flora;
			 mountain.ImageUrls = mountainForm.ImageUrls;

			 await _repository.SaveChangesAsync();

			 return mountain.Id;
         }

	}
}
