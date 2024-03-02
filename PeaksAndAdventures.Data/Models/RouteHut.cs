using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Many-to-many relationship class between route and hut")]
    public class RouteHut
    {
        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = null!;

        [Required]
        [Comment("Navigation property for hut")]
        public int HutId { get; set; }
        [ForeignKey(nameof(HutId))]
        public Hut Hut { get; set; } = null!;
    }
}
