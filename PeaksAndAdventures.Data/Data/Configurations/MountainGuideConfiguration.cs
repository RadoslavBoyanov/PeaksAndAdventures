using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class MountainGuideConfiguration : IEntityTypeConfiguration<MountainGuide>
    {
        public void Configure(EntityTypeBuilder<MountainGuide> builder)
        {
            //builder.HasData(GenerateMountainGuide());
        }

        private MountainGuide[] GenerateMountainGuide()
        {
            ICollection<MountainGuide> mountainGuides = new List<MountainGuide>();

            return mountainGuides.ToArray();
        }
    }
}
