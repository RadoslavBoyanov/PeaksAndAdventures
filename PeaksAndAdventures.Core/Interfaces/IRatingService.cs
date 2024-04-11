using PeaksAndAdventures.Core.Models.ViewModels.Rating;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRatingService
	{
		Task AddRatingAsync(int id, string entityType , int value);
		Task<double?> GetAverageRatingAsync(int id);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByAgencyAsync(int agencyId);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByGuideAsync(int guideId);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByRouteAsync(int routeId);
    }
}
