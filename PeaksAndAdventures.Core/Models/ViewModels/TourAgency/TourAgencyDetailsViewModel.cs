namespace PeaksAndAdventures.Core.Models.ViewModels.TourAgency
{
    /// <summary>
    /// view model for details
    /// </summary>
    public class TourAgencyDetailsViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;

        public double? Rating { get; set; }

        public string OwnerId { get; set; } = string.Empty;
    }
}
