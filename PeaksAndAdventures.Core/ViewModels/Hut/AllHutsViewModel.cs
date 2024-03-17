namespace PeaksAndAdventures.Core.ViewModels.Hut
{
	public class AllHutsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string WorkTime { get; set; }
        public int Places { get; set; }
        public string Camping { get; set; }
        public double? Altitude { get; set; }
        public string HasBathroom { get; set; }
        public string HasToilet { get; set; }
        public string HasCanteen { get; set; }
        public string? Phone { get; set; }
        public string? ImageUrl { get; set; }
        public int MountainId { get; set; }
        public string MountainName { get; set; } = string.Empty;
	}
}
