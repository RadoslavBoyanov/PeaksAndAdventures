using PeaksAndAdventures.Core.Models.ViewModels.Rating;

namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRatingService
	{
		Task AddRatingAsync(int id, string entityType , int value);
        Task<double?> GetAverageRatingByGuideAsync(int guideId);
        Task<double?> GetAverageRatingByAgencyAsync(int agencyId);
        Task<double?> GetAverageRatingByRouteAsync(int routeId);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByAgencyAsync(int agencyId);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByGuideAsync(int guideId);
        Task<List<RatingDistributionViewModel>> GetRatingDistributionByRouteAsync(int routeId);
        Task DeleteRatings (int id, string entityType);
    }
}
