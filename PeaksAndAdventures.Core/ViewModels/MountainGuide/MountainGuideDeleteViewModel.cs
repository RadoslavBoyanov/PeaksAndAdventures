﻿using PeaksAndAdventures.Core.ViewModels.Mountain;
using PeaksAndAdventures.Core.ViewModels.Route;

namespace PeaksAndAdventures.Core.ViewModels.MountainGuide
{
	/// <summary>
	/// view model for delete mountain guide
	/// </summary>
	public class MountainGuideDeleteViewModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public List<GetAllRoutesViewModel> Routes { get; set; }
		public List<GetAllMountainsViewModel> Mountains { get; set; }

	}
}
