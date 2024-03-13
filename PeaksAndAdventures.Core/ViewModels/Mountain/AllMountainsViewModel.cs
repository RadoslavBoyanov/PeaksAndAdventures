﻿namespace PeaksAndAdventures.Core.ViewModels.Mountain
{
    public class AllMountainsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Climate { get; set; }
       
        public string Waters { get; set; }

        public string Flora { get; set; } 

        public string Fauna { get; set; } 

        public string? ImageUrls { get; set; }

        public string MountainName { get; set; } = string.Empty;
	}
}