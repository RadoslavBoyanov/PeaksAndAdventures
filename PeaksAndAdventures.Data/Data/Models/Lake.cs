using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.LakeValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Lake entity model")]
    public class Lake
    {
        [Key]
        [Comment("Lake Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Lake name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(DescriptionMaxLength)]
        [Comment("Lake description")]
        public string? Description { get; set; }

        [Comment("Pictures of the lake")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Navigation property for mountain")]
        public int MountainId { get; set; }

        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;

        public ICollection<Route> Routes { get; set; } = new HashSet<Route>();
    }
}
