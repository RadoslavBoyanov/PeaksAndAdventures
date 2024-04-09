namespace PeaksAndAdventures.Core.Models.ViewModels.Peak
{
    /// <summary>
    /// view model for deleting a peak
    /// </summary>
    public class PeakDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string MountainName { get; set; } = null!;
    }
}
