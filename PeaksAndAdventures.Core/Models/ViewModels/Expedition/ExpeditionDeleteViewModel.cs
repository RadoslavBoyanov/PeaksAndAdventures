namespace PeaksAndAdventures.Core.Models.ViewModels.Expedition
{
    /// <summary>
    /// view model for deleting expedition, inherits from ExpeditionAllViewModel
    /// </summary>
    public class ExpeditionDeleteViewModel : ExpeditionAllViewModel
    {
        public string TourAgencyName { get; set; } = null!;
        public string OrganiserId { get; set; } = null!;
    }
}
