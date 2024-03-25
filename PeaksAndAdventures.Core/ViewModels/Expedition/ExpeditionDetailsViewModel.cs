using System.ComponentModel.DataAnnotations;

namespace PeaksAndAdventures.Core.ViewModels.Expedition
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

		[DisplayFormat(DataFormatString = "{0:C}$")]
		public string Price { get; set; } = string.Empty;

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
