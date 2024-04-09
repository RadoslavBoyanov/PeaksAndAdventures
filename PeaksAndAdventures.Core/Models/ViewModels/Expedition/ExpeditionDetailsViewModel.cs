using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Core.Models.ViewModels.Expedition
{
    public class ExpeditionDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Enrolment { get; set; }

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public int Days { get; set; }

        public string Program { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Includes { get; set; } = string.Empty;

        public string Excludes { get; set; } = string.Empty;

        public string? Extras { get; set; }

        public int TourAgencyId { get; set; }

        public string TourAgencyName { get; set; } = string.Empty;

        public string OrganiserId { get; set; } = string.Empty;

        public int RouteId { get; set; }

        public string RouteName { get; set; } = string.Empty;
    }
}
