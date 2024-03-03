using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Many-to-many relationship class between mountain guide and route")]
    public class MountaineerRoute
    {
        [Required]
        [Comment("Navigation property for mountain guide")]
        public int MountainGuideId { get; set; }
        [ForeignKey(nameof(MountainGuideId))]
        public MountainGuide MountainGuide { get; set; } = null!;

        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = null!;
    }
}
