namespace PeaksAndAdventures.Core.ViewModels.Lake
{
	/// <summary>
	/// view model for details of a lake
	/// </summary>
	public class LakeDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public string MountainName { get; set; } = null!;
	}
}
