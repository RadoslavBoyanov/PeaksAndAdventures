using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Infrastructure.Data.Enums.Route;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.RouteValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Route entity model")]
    public class Route
    {
        [Key]
        [Comment("Route id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Route key names")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(StartingPointMaxLength)]
        [Comment("Route starting point")]
        [Column("Starting point")]
        public string StartingPoint { get; set; } = string.Empty;

        [Required]
        [Comment("Route displacement positive")]
        [Column("Displacement positive")]
        public double DisplacementPositive { get; set; }

        [Required]
        [Comment("Route displacement negative")]
        [Column("Displacement negative")]
        public double DisplacementNegative { get; set; }

        [Required]
        [Comment("Route difficulty")]
        public Difficulty Difficulty { get; set; }

        [Required]
        [Comment("Route duration")]
        public TimeSpan Duration { get; set; }

        [Comment("Route rating")]
        public double? Rating { get; set; }

        [Comment("Pictures of the route")]
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Route description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Navigation property for mountain")]
        public int MountainId { get; set; }
        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        public ICollection<RoutePeak> RoutesPeaks { get; set; } = new HashSet<RoutePeak>();
        public ICollection<RouteHut> RoutesHuts { get; set; } = new HashSet<RouteHut>();
        public ICollection<RouteLake> RoutesLakes { get; set; } = new HashSet<RouteLake>();
        public ICollection<RouteWaterfall> RouteWaterfalls { get; set; } = new HashSet<RouteWaterfall>();
        public ICollection<MountaineerRoute> MountaineersRoutes { get; set; } = new HashSet<MountaineerRoute>();
        public ICollection<Expedition> Expeditions { get; set; } = new List<Expedition>();
    }
}
