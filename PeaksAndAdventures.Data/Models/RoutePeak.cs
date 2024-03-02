using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Many-to-many relationship class between route and peak")]
    public class RoutePeak
    {
        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = null!;

        [Required]
        [Comment("Navigation property for peak")]
        public int PeakId { get; set; }
        [ForeignKey(nameof(PeakId))]
        public Peak Peak { get; set; } = null!;
    }
}
