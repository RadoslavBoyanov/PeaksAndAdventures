using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
	[Comment("Entity for ratings")]
	public class Rating
	{
		[Key]
		[Comment("Rating Id")]
		public int Id { get; set; }
	
		[Comment("Navigation property for route")]
		public int? RouteId { get; set; }
		[Comment("Rating entity type")]
		[ForeignKey(nameof(RouteId))]
		public Route? Route { get; set; }

		[Comment("Navigation property for tour agency")]
		public int? TourAgencyId { get; set; }
		[ForeignKey(nameof(TourAgencyId))]
		public TourAgency? TourAgency { get; set; }

		[Comment("Navigation property for mountain guide")]
		public int? MountainGuideId { get; set; }
		[ForeignKey(nameof(MountainGuideId))] 
		public MountainGuide? MountainGuide { get; set; }
		[Required]
		[Comment("Name of object")]
		public string Name { get; set; } = string.Empty;

		[NotMapped]
		public List<int> Values { get; set; } = new List<int>();
	}
}
