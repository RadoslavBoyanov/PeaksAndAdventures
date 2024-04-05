namespace PeaksAndAdventures.Core.ViewModels.Peak
{
	/// <summary>
	/// view model for peak details
	/// </summary>
	public class PeakDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }

		public int Altitude { get; set; }

		public string? Partition { get; set; }

		public string? SpecificLocation { get; set; }

		public string? ImageUrl { get; set; }

		public int MountainId { get; set; }

		public string MountainName { get; set; } = string.Empty;
	}
}
