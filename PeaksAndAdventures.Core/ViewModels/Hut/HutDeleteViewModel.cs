namespace PeaksAndAdventures.Core.ViewModels.Hut
{
	/// <summary>
	/// view model for deleting a hut
	/// </summary>
	public class HutDeleteViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string MountainName { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;
	}
}
