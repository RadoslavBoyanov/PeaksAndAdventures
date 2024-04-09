using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.HutValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Hut
{
    /// <summary>
    /// View model for edit a hut
    /// </summary>
    public class HutEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Работно време")]
        public WorkTime WorkTime { get; set; }

        [Display(Name = "Места")]
        public int Places { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Къмпинг")]
        public Camping Camping { get; set; }

        [Display(Name = "Надморска височина")]
        public int? Altitude { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Баня")]
        public bool HasBathroom { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Тоалетна")]
        public bool HasToilet { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Столова")]
        public bool HasCanteen { get; set; }


        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Изображение - URL адрес")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
