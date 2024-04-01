namespace PeaksAndAdventures.Core.ViewModels.Route
{
	public class RouteDeleteViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string StartingPoint { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string MountainName { get; set; } = null!;
		public string? ImageUrl { get; set; }
	}
}
