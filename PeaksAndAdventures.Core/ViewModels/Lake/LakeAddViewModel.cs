using PeaksAndAdventures.Core.ViewModels.Mountain;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.LakeValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Lake
{
	public class LakeAddViewModel
	{
		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Име")]
		public string Name { get; set; } = string.Empty;

		[StringLength(DescriptionMaxLength, ErrorMessage = StringMaximumLength)]
		[Display(Name = "Описание")]
		public string? Description { get; set; }

		[Display(Name = "Изображение")]
		public string? ImageUrl { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		public int MountainId { get; set; }

		[Required]
		public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();
	}
}
