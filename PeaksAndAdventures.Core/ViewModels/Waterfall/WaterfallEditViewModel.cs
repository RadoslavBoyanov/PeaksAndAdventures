using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.WaterfallValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Waterfall
{
	/// <summary>
	/// View model for edit 
	/// </summary>
	public class WaterfallEditViewModel
	{
		public int  Id { get; set; }
		
		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(NameMaxLength,
			MinimumLength = NameMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Име")]
		public string Name { get; set; } = string.Empty;

		[StringLength(DescriptionMaxLength, ErrorMessage = StringMaximumLength)]
		[Display(Name = "Описание")]
		public string? Description { get; set; }

		[Display(Name = "Изображение - URL адрес")]
		public string? ImageUrl { get; set; }
	}
}
