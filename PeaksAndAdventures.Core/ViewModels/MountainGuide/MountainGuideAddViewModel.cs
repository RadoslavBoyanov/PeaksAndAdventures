using System.ComponentModel.DataAnnotations;
using PeaksAndAdventures.Core.ViewModels.TourAgency;
using static PeaksAndAdventures.Common.EntityValidations.MountainGuideValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.MountainGuide
{
    public class MountainGuideAddViewModel
    {

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Собствено име")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Range(AgeMin, AgeMax)]
        [Display(Name = "Години")]
        public int? Age { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(EmailMaxLength,
            MinimumLength = EmailMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(ExperienceMinYears, ExperienceMaxYears)]
        [Display(Name = "Опит")]
        public int Experience { get; set; }

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        public int? TourAgencyId { get; set; }

        public IEnumerable<TourAgencyGetViewModel> TourAgencies { get; set; } = new List<TourAgencyGetViewModel>();
    }
}
