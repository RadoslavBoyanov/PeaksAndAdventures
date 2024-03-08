using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.PeakValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Peak model")]
    public class Peak
    {
        [Key]
        [Comment("Peak Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Peak name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(DescriptionMaxLength)]
        [Comment("Peak description")]
        public string? Description { get; set; }

        [Required]
        [Comment("Peak altitude")]
        public int Altitude { get; set; }

        [StringLength(PartitionMaxLength)]
        [Comment("Partition in mountain where is the peak")]
        public string? Partition { get; set; }

        [StringLength(SpecificLocationMaxLength)]
        [Comment("Peak specific location")]
        public string? SpecificLocation { get; set; }

        [Comment("Pictures of the peak")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Mountain id for the peak")]
        public int MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        public ICollection<RoutePeak> RoutesPeaks { get; set; } = new HashSet<RoutePeak>();
    }
}
