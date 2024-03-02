using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.TourAgencyValidation;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Tour agency entity model")]
    public class TourAgency
    {
        [Key]
        [Comment("Tour agency id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Tour agency name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Tour agency description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(EmailMaxLength)]
        [Comment("Tour agency email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Tour agency phone number")]
        public string Phone { get; set; } = string.Empty;

        [Comment("Tour agency rating")]
        public double? Rating { get; set; }

        [Required]
        [Comment("Tour agency owner")]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))] 
        public IdentityUser Owner { get; set; } = null!;

        public ICollection<Expedition> Expeditions { get; set; } = new HashSet<Expedition>();

        public ICollection<MountainGuide> MountainGuides { get; set; } = new HashSet<MountainGuide>();
    }
}
