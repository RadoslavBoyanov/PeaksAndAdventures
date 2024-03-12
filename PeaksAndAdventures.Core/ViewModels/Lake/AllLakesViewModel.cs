namespace PeaksAndAdventures.Core.ViewModels.Lake
{
    public class AllLakesViewModel
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
        public int MountainId { get; set; }
        public string MountainName { get; set; } = string.Empty;
	}
}
