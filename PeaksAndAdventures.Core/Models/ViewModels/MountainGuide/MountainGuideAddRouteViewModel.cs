﻿using PeaksAndAdventures.Core.Models.ViewModels.Route;

namespace PeaksAndAdventures.Core.Models.ViewModels.MountainGuide
{
    /// <summary>
    /// view model for adding a route to mountain guide
    /// </summary>
    public class MountainGuideAddRouteViewModel
    {
        public int Id { get; set; }

        public string OwnerId { get; set; } = null!;

        public IEnumerable<GetAllRoutesViewModel> Routes { get; set; } = new List<GetAllRoutesViewModel>();
    }
}
