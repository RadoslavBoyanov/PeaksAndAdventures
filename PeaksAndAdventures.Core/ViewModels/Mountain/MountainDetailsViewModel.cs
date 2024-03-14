namespace PeaksAndAdventures.Core.ViewModels.Mountain
{
	public class MountainDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;

		public string Climate { get; set; } = string.Empty;

		public string Waters { get; set; } = string.Empty;

		public string Flora { get; set; } = string.Empty;

		public string Fauna { get; set; } = string.Empty;

		public string? ImageUrls { get; set; }
	}
}
