namespace PeaksAndAdventures.Core.Models.ViewModels.Route
{
    public class RouteDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string StartingPoint { get; set; } = string.Empty;


        public double DisplacementPositive { get; set; }

        public double DisplacementNegative { get; set; }

        public string Difficulty { get; set; } = null!;

        public string Duration { get; set; } = string.Empty;


        public double? Rating { get; set; }

        public string? ImageUrl { get; set; }

        public string Description { get; set; } = string.Empty;

        public int MountainId { get; set; }

        public string MountainName { get; set; } = string.Empty;
    }
}
