using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.ViewModels.MountainGuide;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
	public class MountainGuideService : IMountainGuideService
	{
		private readonly IRepository _repository;

		public MountainGuideService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<MountainGuideAllViewModel>> AllAsync()
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.Select(mg => new MountainGuideAllViewModel()
				{
					Id = mg.Id,
					FirstName = mg.FirstName,
					LastName = mg.LastName,
					ImageUrl = mg.ImageUrl,
				})
				.ToListAsync();
		}

		public async Task<bool> CheckIfExistMountainGuideByIdAsync(int mountainGuideId)
		{
			return await _repository.AllReadOnly<MountainGuide>()
				.AnyAsync(mg => mg.Id == mountainGuideId);
		}

		public async Task<MountainGuideDetailsViewModel> DetailsAsync(int mountainGuideId)
		{
			var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(mountainGuideId);

			var tourAgency = await _repository.GetByIdAsync<TourAgency>(mountainGuide.TourAgencyId);
			string tourAgencyName = tourAgency?.Name ?? string.Empty;

			var mountainGuideInformation = new MountainGuideDetailsViewModel()
			{
				Id = mountainGuide.Id,
				FirstName = mountainGuide.FirstName,
				LastName = mountainGuide.LastName,
				Age = mountainGuide.Age.ToString(),
				Email = mountainGuide.Email,
				Phone = mountainGuide.Phone,
				Experience = mountainGuide.Experience,
				Rating = mountainGuide.Rating.ToString(),
				ImageUrl = mountainGuide.ImageUrl,
				OwnerId = mountainGuide.OwnerId,
				TourAgencyId = mountainGuide.TourAgencyId,
				TourAgencyName = tourAgencyName,
			};

			return mountainGuideInformation;
		}

		public async Task<MountainGuideEditViewModel> EditGetAsync(int mountainGuideId)
		{
			var currentMountainGuide = await _repository.All<MountainGuide>()
                .Include(mg => mg.TourAgency)
				.FirstOrDefaultAsync(mg => mg.Id == mountainGuideId);

			var mountainGuide = new MountainGuideEditViewModel()
			{
				Id = currentMountainGuide.Id,
				FirstName = currentMountainGuide.FirstName,
				LastName = currentMountainGuide.LastName,
				Age = currentMountainGuide.Age,
				Email = currentMountainGuide.Email,
				Phone = currentMountainGuide.Phone,
				Experience = currentMountainGuide.Experience,
				ImageUrl = currentMountainGuide.ImageUrl,
				OwnerId = currentMountainGuide.OwnerId,
				TourAgencyId = currentMountainGuide.TourAgencyId,
				TourAgencyName = currentMountainGuide.TourAgency.Name
			};

			return mountainGuide;
		}

		public async Task<int> EditPostAsync(MountainGuideEditViewModel mountainGuideEdit)
		{
			var mountaineGuide = await _repository.All<MountainGuide>()
                .Include(mg => mg.TourAgency)
				.Where(mg => mg.Id == mountainGuideEdit.Id)
				.FirstOrDefaultAsync();

			mountaineGuide.FirstName = mountainGuideEdit.FirstName;
			mountaineGuide.LastName = mountainGuideEdit.LastName;
			mountaineGuide.Age = mountainGuideEdit.Age;
			mountaineGuide.Email = mountainGuideEdit.Email;
			mountaineGuide.Phone = mountainGuideEdit.Phone;
			mountaineGuide.Experience = mountainGuideEdit.Experience;
			mountaineGuide.ImageUrl = mountainGuideEdit.ImageUrl;
			mountaineGuide.TourAgencyId = mountainGuideEdit.TourAgencyId;

			await _repository.SaveChangesAsync();

			return mountaineGuide.Id;
		}
	}
}
