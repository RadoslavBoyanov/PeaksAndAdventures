using System.ComponentModel.DataAnnotations;
using static PeaksAndAdventures.Common.EntityValidations.MountainValidation;
using static PeaksAndAdventures.Common.ErrorMessages;

namespace PeaksAndAdventures.Core.ViewModels.Mountain
{
	/// <summary>
	/// View model for edit
	/// </summary>
	public class MountainEditViewModel : MountainFormViewModel
	{
		public int Id { get; set; }
	}
}
