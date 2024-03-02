using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PeaksAndAdventures.Common.EntityValidations.MountainGuideValidation;

namespace PeaksAndAdventures.Infrastructure.Models
{
    [Comment("Mountain guide entity model")]
    public class MountainGuide
    {
        [Key]
        [Comment("Mountain guide id")]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Mountain guide first name")]
        [Column("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Mountain guide last name")]
        [Column("Last name")]
        public string LastName { get; set; } = string.Empty;

        [Comment("Mountain guide age")]
        public int? Age { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Mountain guide phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(EmailMaxLength)]
        [Comment("Mountain guide email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Comment("Mountain guide experience")]
        public int Experience { get; set; }

        [Comment("Mountain guide rating")]
        public double? Rating { get; set; }

        [Comment("Mountain guide profile picture")]
        public string? ImageUrl { get; set; }

        [Comment("Mountain guide tour agency")]
        public int? TourAgencyId { get; set; }
        [ForeignKey(nameof(TourAgencyId))] 
        public TourAgency TourAgency { get; set; } = null!;

        [Required]
        [Comment("Navigation property for owner on the model")]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))] 
        public IdentityUser Owner { get; set; } = null!;
 
        public ICollection<Mountain> Mountains { get; set; } = new HashSet<Mountain>();
        public ICollection<Route> Routes { get; set; } = new HashSet<Route>();
    }
}
