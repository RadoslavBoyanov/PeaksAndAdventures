using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Models.ViewModels.Rating;
using PeaksAndAdventures.Infrastructure.Data.Common;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Core.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRepository _repository;

		public RatingService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task AddRatingAsync(int id, string entityType, int value)
		{

			if (entityType == "Route")
			{
				var route = await _repository.GetByIdAsync<Route>(id);
				var ratingRoute = await _repository.All<Rating>()
					.Where(r => r.RouteId == id)
					.FirstOrDefaultAsync();


				if (ratingRoute != null)
				{
					ratingRoute.Values.Add(value);
				}
				else
				{
					var routeRating = new Rating()
					{
						RouteId = id,
						Route = route,
						Name = route.Name,
						Values = new List<int> { value },
					};

					await _repository.AddAsync(routeRating);
				}
			}

			if (entityType == "TourAgency")
			{
				var tourAgency = await _repository.GetByIdAsync<TourAgency>(id);
				var ratingTourAgency = await _repository.All<Rating>()
					.Where(r => r.TourAgencyId == id)
					.FirstOrDefaultAsync();

				if (ratingTourAgency != null)
				{
					ratingTourAgency.Values.Add(value);
				}
				else
				{
					var tourAgencyRating = new Rating()
					{
						TourAgencyId = id,
						TourAgency = tourAgency,
						Name = tourAgency.Name,
						Values = new List<int> { value },
					};

					await _repository.AddAsync(tourAgencyRating);
				}
			}

			if (entityType == "MountainGuide")
			{
				var mountainGuide = await _repository.GetByIdAsync<MountainGuide>(id);
				var ratingMountainGuide = await _repository.All<Rating>()
					.Where(r => r.MountainGuideId == id)
					.FirstOrDefaultAsync();

				if (ratingMountainGuide != null)
				{
					ratingMountainGuide.Values.Add(value);
				}
				else
				{
					Console.WriteLine($"Value: {value}");
					var mountainGuideRating = new Rating()
					{
						MountainGuideId = id,
						MountainGuide = mountainGuide,
						Name = $"{mountainGuide.FirstName} {mountainGuide.LastName}",
						Values = new List<int> { value },
					};

					await _repository.AddAsync(mountainGuideRating);
				}
			}


			await _repository.SaveChangesAsync();
		}

        public async Task<double?> GetAverageRatingByGuideAsync(int guideId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.MountainGuideId == guideId).ToListAsync();
            return CalculateAverageRating(ratings);
        }

        public async Task<double?> GetAverageRatingByAgencyAsync(int agencyId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.TourAgencyId == agencyId).ToListAsync();
            return CalculateAverageRating(ratings);
        }

        public async Task<double?> GetAverageRatingByRouteAsync(int routeId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.RouteId == routeId).ToListAsync();
            return CalculateAverageRating(ratings);
        }

        private double? CalculateAverageRating(List<Rating> ratings)
        {
            if (!ratings.Any())
            {
                return null;
            }

            var totalRatingCount = ratings.Sum(r => r.Values?.Count ?? 0);

            if (totalRatingCount == 0)
            {
                return null;
            }

            var totalRatingSum = ratings.Sum(r => r.Values?.Sum() ?? 0);
            double averageRating = (double)totalRatingSum / totalRatingCount;
            return Math.Round(averageRating, 2);
        }


        public async Task<List<RatingDistributionViewModel>> GetRatingDistributionByGuideAsync(int guideId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.MountainGuideId == guideId).ToListAsync();
            return CalculateRatingDistribution(ratings);
        }

        public async Task<List<RatingDistributionViewModel>> GetRatingDistributionByAgencyAsync(int agencyId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.TourAgencyId == agencyId).ToListAsync();
            return CalculateRatingDistribution(ratings);
        }

        public async Task<List<RatingDistributionViewModel>> GetRatingDistributionByRouteAsync(int routeId)
        {
            var ratings = await _repository.All<Rating>().Where(x => x.RouteId == routeId).ToListAsync();
            return CalculateRatingDistribution(ratings);
        }

        private List<RatingDistributionViewModel> CalculateRatingDistribution(List<Rating> ratings)
        {
            var ratingDistribution = InitializeRatingDistribution();

            foreach (var rating in ratings)
            {
                foreach (var value in rating.Values)
                {
                    var ratingViewModel = ratingDistribution.FirstOrDefault(r => r.Rating == value);
                    if (ratingViewModel != null)
                    {
                        ratingViewModel.Count++;
                    }
                }
            }

            return ratingDistribution;
        }

        private List<RatingDistributionViewModel> InitializeRatingDistribution()
        {
            var ratingDistribution = new List<RatingDistributionViewModel>();

            for (int i = 1; i <= 5; i++)
            {
                ratingDistribution.Add(new RatingDistributionViewModel { Rating = i, Count = 0 });
            }

            return ratingDistribution;
        }

    }
}
