namespace PeaksAndAdventures.Core.Models.ViewModels.TourAgency
{
    /// <summary>
    /// view model for delete tour agency
    /// </summary>
    public class TourAgencyDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string OwnerId { get; set; }
    }
}
