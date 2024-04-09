using System.ComponentModel.DataAnnotations;
using PeaksAndAdventures.Common;
using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using static PeaksAndAdventures.Common.EntityValidations.PeakValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Peak
{
    public class PeakAddViewModel
    {
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

        [Required(ErrorMessage = RequireErrorMessage)]
        public int MountainId { get; set; }

        [Required]
        public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();
    }
}
