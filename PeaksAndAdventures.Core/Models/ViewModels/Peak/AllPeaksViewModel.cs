using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaksAndAdventures.Core.Models.ViewModels.Peak
{
    /// <summary>
    /// view model for all peaks
    /// </summary>
    public class AllPeaksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Altitude { get; set; }

        public string? ImageUrl { get; set; }

        public int MountainId { get; set; }

        public string MountainName { get; set; } = string.Empty;
    }
}
