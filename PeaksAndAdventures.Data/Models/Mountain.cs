using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.MountainValidation;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Mountain model")]
    public class Mountain
    {
        [Key]
        [Comment("Mountain Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Mountain name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(LocationMaxLength)]
        [Comment("Mountain location")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(ClimateMaxLength)]
        [Comment("Mountain climate")]
        public string Climate { get; set; } = string.Empty;

        [Required]
        [StringLength(WatersMaxLength)]
        [Comment("Mountain waters")]
        public string Waters { get; set; } = string.Empty;

        [Required]
        [StringLength(FloraMaxLength)]
        [Comment("Mountain flora")]
        public string Flora { get; set; } = string.Empty;

        [Required]
        [StringLength(FaunaMaxLength)]
        [Comment("Mountain fauna")]
        public string Fauna { get; set; } = string.Empty;

        [Required]
        [Comment("Pictures of the mountain")]
        public string ImageUrls { get; set; } = string.Empty;

        public ICollection<Peak> Peaks { get; set; } = new HashSet<Peak>();
        public ICollection<Lake> Lakes { get; set; } = new HashSet<Lake>();
        public ICollection<Waterfall> Waterfalls { get; set; } = new HashSet<Waterfall>();
        public ICollection<Hut> Huts { get; set; } = new HashSet<Hut>();
    }
}
