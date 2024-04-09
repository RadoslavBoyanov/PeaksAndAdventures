using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.PeakValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Peak
{

    /// <summary>
    /// View model for edit
    /// </summary>
    public class PeakEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [StringLength(DescriptionMaxLength, ErrorMessage = StringMaximumLength)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        [Range(LowestAltitude, HighestAltitude)]
        [Display(Name = "Надморска височина")]
        public int Altitude { get; set; }

        [StringLength(PartitionMaxLength, ErrorMessage = StringMaximumLength)]
        [Display(Name = "Дял")]
        public string? Partition { get; set; }

        [StringLength(SpecificLocationMaxLength, ErrorMessage = StringMaximumLength)]
        [Display(Name = "Допълнително уточнение на местоположението")]
        public string? SpecificLocation { get; set; }

        [Display(Name = "Изображение")]
        public string? ImageUrl { get; set; }
    }
}
