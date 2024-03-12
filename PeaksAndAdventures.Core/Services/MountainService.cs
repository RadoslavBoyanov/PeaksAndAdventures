﻿using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.Hut;
using PeaksAndAdventures.Core.ViewModels.Lake;
using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Peak;
using PeaksAndAdventures.Core.ViewModels.Waterfall;
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
                     Location = m.Location,
                     Climate = m.Climate,
                     Waters = m.Waters,
                     Fauna = m.Fauna,
                     Flora = m.Flora,
                     ImageUrls = m.ImageUrls
                 })
                 .ToListAsync();
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
			         WorkTime = h.WorkTime.ToString(),
			         HasToilet = h.HasToilet ? "да" : "не",
			         HasCanteen = h.HasCanteen ? "да" : "не",
			         HasBathroom = h.HasBathroom ? "да" : "не",
			         Camping = h.Camping.ToString(),
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

         public async Task<bool> CheckMountainExistsAsync(string mountainName)
         {
			return await _repository.AllReadOnly<Mountain>()
				.AnyAsync(m => m.Name == mountainName);
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

       
    }
}
