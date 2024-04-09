using PeaksAndAdventures.Core.Models.ViewModels.Mountain;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.WaterfallValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Models.ViewModels.Waterfall
{
    public class WaterfallAddViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DescriptionMaxLength, ErrorMessage = StringMaximumLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [Display(Name = "Изображение - URL адрес")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int MountainId { get; set; }

        [Required]
        public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();
    }
}
