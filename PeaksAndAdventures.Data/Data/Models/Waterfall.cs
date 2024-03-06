using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.WaterfallValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Waterfall entity model")]
    public class Waterfall
    {
        [Key]
        [Comment("Waterfall id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Waterfall name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(DescriptionMaxLength)]
        [Comment("Waterfall description")]
        public string? Description { get; set; }

        [Comment("Pictures of the waterfall")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Navigation property for mountain")]
        public int MountainId { get; set; }
        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        public ICollection<RouteWaterfall> RoutesWaterfalls { get; set; } = new HashSet<RouteWaterfall>();  
    }
}
