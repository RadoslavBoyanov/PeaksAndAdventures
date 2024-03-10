using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaksAndAdventures.Core.ViewModels.Peak
{
    public class AllPeaksViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int Altitude { get; set; }

        public string? Partition { get; set; }

        public string? SpecificLocation { get; set; }

        public string? ImageUrl { get; set; }

        public int MountainId { get; set; }
    }
}
