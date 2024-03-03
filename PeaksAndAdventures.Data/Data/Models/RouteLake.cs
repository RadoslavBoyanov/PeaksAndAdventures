using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Many-to-many relationship class between route and lake")]
    public class RouteLake
    {
        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = null!;

        [Required]
        [Comment("Navigation property for lake")]
        public int LakeId { get; set; }
        [ForeignKey(nameof(LakeId))]
        public Lake Lake { get; set; } = null!;
    }
}
