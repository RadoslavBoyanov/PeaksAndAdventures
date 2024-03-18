using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Core.Services
{
	public class MountainGuideService : IMountainGuideService
	{
		private readonly IRepository _repository;

		public MountainGuideService(IRepository repository)
		{
			_repository = repository;
		}
	}
}
