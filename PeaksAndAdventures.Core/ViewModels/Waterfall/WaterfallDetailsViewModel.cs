namespace PeaksAndAdventures.Core.ViewModels.Waterfall
{
	/// <summary>
	/// view model for waterfall details
	/// </summary>
	public class WaterfallDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public string MountainName { get; set; } = null!;
	}
}
