using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.MountainValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Mountain
{
	/// <summary>
	/// View model for add
	/// </summary>
	public class MountainFormViewModel
	{
		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Име")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(LocationMaxLength, MinimumLength = LocationMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Местоположение")]
		public string Location { get; set; } = string.Empty;


		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(ClimateMaxLength, MinimumLength = ClimateMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Климат")]
		public string Climate { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(WatersMaxLength, MinimumLength = WatersMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Води")]
		public string Waters { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(FloraMaxLength, MinimumLength = FloraMinLength, ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Флора")]
		public string Flora { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(FaunaMaxLength, MinimumLength = FaunaMinLength, ErrorMessage = StringLengthErrorMessage)]
		public string Fauna { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[Display(Name = "Изображение - URL адрес")]
		public string ImageUrls { get; set; } = string.Empty;
	}
}
