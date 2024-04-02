namespace PeaksAndAdventures.Core.Interfaces
{
	public interface IRatingService
	{
		Task AddRatingAsync(int id, string entityType , int value);
		Task<double?> GetAverageRatingAsync(int id);
		Task<Dictionary<int, int>> GetRatingDistributionAsync(int id);
	}
}
