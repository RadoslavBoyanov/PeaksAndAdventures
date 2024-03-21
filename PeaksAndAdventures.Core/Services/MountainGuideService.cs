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
	}
}
