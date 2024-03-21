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

		//public async Task<TourAgency> GetAgencyForGuideAsync(int mountainGuideId)
		//{
		//	var guide = await _repository.AllReadOnly<TourAgency>()
		//		.Where(x=>x.MountainGuides.Contains())
		//}
	}
}
