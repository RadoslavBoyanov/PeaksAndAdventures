using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class WaterfallConfiguration : IEntityTypeConfiguration<Waterfall>
    {
        public void Configure(EntityTypeBuilder<Waterfall> builder)
        {
            //builder.HasData(GenerateWaterfalls());
        }

        private Waterfall[] GenerateWaterfalls()
        {
            ICollection<Waterfall> waterfalls = new HashSet<Waterfall>();

            return waterfalls.ToArray();
        }
    }
}
