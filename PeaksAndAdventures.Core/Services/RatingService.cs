﻿using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
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

		public async Task<double?> GetAverageRatingAsync(int id)
		{
			var ratings = _repository.All<Rating>()
				.Where(x => x.RouteId == id || x.TourAgencyId == id || x.MountainGuideId == id)
				.ToList(); 

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
			string formattedRating = averageRating.ToString("F2");
			return double.Parse(formattedRating);
		}

		public async Task<Dictionary<int, int>> GetRatingDistributionAsync(int id)
		{
			var ratings = _repository.All<Rating>().Where(x => x.RouteId == id || x.TourAgencyId == id || x.MountainGuideId == id).ToList();
			var ratingDistribution = new Dictionary<int, int>
			{
				{ 1, 0 },
				{ 2, 0 },
				{ 3, 0 },
				{ 4, 0 },
				{ 5, 0 }
			};

			foreach (var rating in ratings)
			{
				foreach (var value in rating.Values)
				{
					if (ratingDistribution.ContainsKey(value))
					{
						ratingDistribution[value]++;
					}
				}
			}

			return await Task.FromResult(ratingDistribution);
		}
	}
}