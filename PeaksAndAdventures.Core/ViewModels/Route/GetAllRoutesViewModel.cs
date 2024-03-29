namespace PeaksAndAdventures.Core.ViewModels.Route
{
	/// <summary>
	/// view model for taking only name and id from routes
	/// </summary>
	public class GetAllRoutesViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; } 

	}
}
