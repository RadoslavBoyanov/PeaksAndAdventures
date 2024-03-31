using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.Attributes
{
	/// <summary>
	/// custom attribute for duration in entity - Route
	/// </summary>
	public class DurationAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value != null)
			{
				string stringValue = value.ToString();

				// Checking with regular expression for format duration "40.00:00" where is "days.hours:minutes"
				Regex regex = new Regex(@"^\d+\.\d{2}:\d{2}$");

				if (!regex.IsMatch(stringValue))
				{
					return new ValidationResult(DurationFormatIsWrong);
				}

				return ValidationResult.Success;
			}

			return ValidationResult.Success;
		}
	}
}
