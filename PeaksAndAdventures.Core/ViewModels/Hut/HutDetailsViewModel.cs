namespace PeaksAndAdventures.Core.ViewModels.Hut
{
    /// <summary>
    /// hut details view model
    /// </summary>
	public class HutDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string WorkTime { get; set; } = null!;
        public int Places { get; set; }
        public string Camping { get; set; } = null!;
        public double? Altitude { get; set; }
        public string HasBathroom { get; set; } = null!;
        public string HasToilet { get; set; } = null!;
        public string HasCanteen { get; set; } = null!;
        public string? Phone { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int MountainId { get; set; }
        public string MountainName { get; set; } = string.Empty;
	}
}
