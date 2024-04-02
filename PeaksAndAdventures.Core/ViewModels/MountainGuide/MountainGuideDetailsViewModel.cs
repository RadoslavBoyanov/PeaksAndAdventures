namespace PeaksAndAdventures.Core.ViewModels.MountainGuide
{
	public class MountainGuideDetailsViewModel
	{
		public int Id { get; set; }

		
		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string? Age { get; set; }

		public string Phone { get; set; } = string.Empty;

		
		public string Email { get; set; } = string.Empty;

		public int Experience { get; set; }

		public double? Rating { get; set; }

		public string? ImageUrl { get; set; }

		public int? TourAgencyId { get; set; }

		public string OwnerId { get; set; } = string.Empty;
		public string TourAgencyName { get; set; } = string.Empty;
	}
}
