using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Many-to-many relationship class between route and waterfall")]
    public class RouteWaterfall
    {
        [Required]
        [Comment("Navigation property for route")]
        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))] 
        public Route Route { get; set; } = null!;

        [Required]
        [Comment("Navigation property for waterfall")]
        public int WaterfallId { get; set; }
        [ForeignKey(nameof(WaterfallId))] 
        public Waterfall Waterfall { get; set; } = null!;
    }
}
