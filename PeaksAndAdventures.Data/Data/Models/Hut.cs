using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.HutValidation;

namespace PeaksAndAdventures.Infrastructure.Data.Models
{
    [Comment("Hut entity model")]
    public class Hut
    {
        public Hut()
        {
            WorkTime = WorkTime.All;
            Camping = Camping.Permitted;
            HasBathroom = true;
            HasToilet = true;
            HasCanteen = true;
        }

        [Key]
        [Comment("Hut id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Hut name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Hut description - history, location and other things")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Hut work time in seasons")]
        public WorkTime WorkTime { get; set; }

        [Required]
        [Comment("How many people can sleep in hut")]
        public int Places { get; set; }

        [Required]
        [Comment("Camping around the hut")]
        public Camping Camping { get; set; }

        [Comment("Hut altitude")]
        public double? Altitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Hut overnight price")]
        public decimal ОvernightPrice { get; set; }

        [Required]
        [Comment("Hut bathroom")]
        public bool HasBathroom { get; set; }

        [Required]
        [Comment("Hut toilet")]
        public bool HasToilet { get; set; }

        [Required]
        [Comment("Hut canteen")]
        public bool HasCanteen { get; set; }

        [Comment("Pictures of the hut")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Navigation property for mountain")]
        public int MountainId { get; set; }
        [ForeignKey(nameof(MountainId))]
        public Mountain Mountain { get; set; } = null!;
    }
}
