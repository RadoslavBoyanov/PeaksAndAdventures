using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Infrastructure.Data.Enums.Hut;
using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.HutValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Hut
{
	/// <summary>
	/// View model for add hut to mountain
	/// </summary>
	public class AddHutViewModel
	{
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
		public int? Places { get; set; }

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

		[Display(Name = "Изображение - URL адрес")]
		public string? ImageUrl { get; set; }

		[Required(ErrorMessage = RequireErrorMessage)]
		public int MountainId { get; set; }

		[Required]
		public IEnumerable<GetAllMountainsViewModel> Mountains { get; set; } = new List<GetAllMountainsViewModel>();
	}
}
