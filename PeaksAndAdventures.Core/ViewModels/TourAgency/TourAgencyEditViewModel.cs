using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.TourAgencyValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.TourAgency
{
	/// <summary>
	/// view model for edit
	/// </summary>
	public class TourAgencyEditViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(NameMaxLength, 
			MinimumLength = NameMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Име")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(DescriptionMaxLength, 
			MinimumLength = DescriptionMinLength, 
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Описание")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(EmailMaxLength,
			MinimumLength = EmailMinLength,
			ErrorMessage = StringLengthErrorMessage)]
		[EmailAddress]
		[Display(Name = "Имейл")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = RequireErrorMessage)]
		[StringLength(PhoneNumberMaxLength, 
			MinimumLength = PhoneNumberMinLength, 
			ErrorMessage = StringLengthErrorMessage)]
		[Display(Name = "Телефонен номер")]
		public string Phone { get; set; } = string.Empty;


		[Required]
		public string OwnerId { get; set; } = string.Empty;
	}
}
