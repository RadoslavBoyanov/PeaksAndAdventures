namespace PeaksAndAdventures.Core.ViewModels.Waterfall
{
    public class AllWaterfallsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int MountainId { get; set; }

        public string MountainName { get; set; } = string.Empty;
    }
}
