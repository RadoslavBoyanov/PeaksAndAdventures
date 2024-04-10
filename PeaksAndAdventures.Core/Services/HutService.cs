using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.QueryModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Hut;
using PeaksAndAdventures.Core.Models.ViewModels.Route;
using PeaksAndAdventures.Extensions;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;
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
                    ImageUrl = h.ImageUrl,
                })
                .ToListAsync();
        }

        public HutQueryServiceModel All(string? workTime = null, string? camping = null,
            string? searchTerm = null, string? mountainSort = null,
            int currentPage = 1, int hutPerPage = 3)
        {
            var hutsQuery = _repository.AllReadOnly<Hut>()
                .Include(h => h.Mountain)
                .AsQueryable();

			if (!string.IsNullOrEmpty(workTime))
			{
				var workTimeValues = Enum.GetValues(typeof(WorkTime));
				var selectedWorkTime = workTimeValues
					.Cast<WorkTime>()
					.FirstOrDefault(w => EnumExtensions.GetDisplayName(w) == workTime);

				if (selectedWorkTime != null)
				{
					hutsQuery = hutsQuery.Where(h => h.WorkTime == selectedWorkTime);
				}
			}

			if (!string.IsNullOrEmpty(camping))
			{
				var campingValues = Enum.GetValues(typeof(Camping));
				var selectedCamping = campingValues
					.Cast<Camping>()
					.FirstOrDefault(c => EnumExtensions.GetDisplayName(c) == camping);

				if (selectedCamping != null)
				{
					hutsQuery = hutsQuery.Where(h => h.Camping == selectedCamping);
				}
			}

			if (!string.IsNullOrEmpty(searchTerm))
            {
                hutsQuery = hutsQuery.Where(h => h.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(mountainSort))
            {
                hutsQuery = hutsQuery.Where(h => h.Mountain.Name.ToLower().Contains(mountainSort.ToLower()));
            }


            var huts =  hutsQuery.Skip((currentPage - 1) * hutPerPage)
                .Take(hutPerPage)
                .Select(h => new HutServiceModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageUrl = h.ImageUrl,
                })
                .ToList();

            var totalHuts = hutsQuery.Count();

            return new HutQueryServiceModel()
            {
                TotalHuts = totalHuts,
                Huts = huts,
            };
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

        public async Task<HutDetailsViewModel> DetailsAsync(int hutId)
        {
	        var hut = await _repository.AllReadOnly<Hut>()
		        .Include(h=> h.Mountain)
		        .FirstOrDefaultAsync(h => h.Id == hutId);

	        var hutDetails = new HutDetailsViewModel()
	        {
		        Id = hut.Id,
		        Name = hut.Name,
		        Altitude = hut.Altitude,
		        Description = hut.Description,
		        WorkTime = hut.WorkTime.GetDisplayName(),
		        HasToilet = hut.HasToilet ? "да" : "не",
		        HasCanteen = hut.HasCanteen ? "да" : "не",
		        HasBathroom = hut.HasBathroom ? "да" : "не",
		        Camping = hut.Camping.GetDisplayName(),
		        Phone = hut.Phone,
		        ImageUrl = hut.ImageUrl,
		        MountainId = hut.MountainId,
		        MountainName = hut.Mountain.Name
	        };

			return hutDetails;
        }

        public async Task<HutDeleteViewModel> DeleteGetAsync(int hutId)
        {
	        var hut = await _repository.AllReadOnly<Hut>()
		        .Include(h=> h.Mountain)
		        .Where(h => h.Id == hutId)
		        .Select(h => new HutDeleteViewModel()
		        {
			        Id = h.Id,
			        Name = h.Name,
			        MountainName = h.Mountain.Name,
			        Phone = h.Phone,
			        ImageUrl = h.ImageUrl,
		        })
		        .FirstOrDefaultAsync();

	        return hut;
        }

        public async Task<int> DeleteConfirmedAsync(int hutId)
        {
	        var hut = await _repository.All<Hut>()
		        .Include(h => h.RoutesHuts)
		        .FirstOrDefaultAsync(h => h.Id == hutId);

	        if (hut.RoutesHuts.Any())
	        {
		        foreach (var routeHut in hut.RoutesHuts)
		        { 
			        _repository.Delete(routeHut);
		        }
	        }

	        await _repository.DeleteAsync<Hut>(hutId);
			await _repository.SaveChangesAsync();

			return hutId;
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

        public async Task<IEnumerable<GetAllRoutesViewModel>> GetRoutesAsync(int hutId)
        {
	        return await _repository.AllReadOnly<RouteHut>()
		        .Include(rh => rh.Route)
		        .Where(rh => rh.HutId == hutId)
		        .Select(rh => new GetAllRoutesViewModel()
		        {
			        Id = rh.Route.Id,
			        Name = rh.Route.Name,
			        ImageUrl = rh.Route.ImageUrl,
		        })
		        .ToListAsync();
        }
    }
}
