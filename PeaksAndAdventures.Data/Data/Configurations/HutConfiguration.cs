using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class HutConfiguration : IEntityTypeConfiguration<Hut>
    {
        public void Configure(EntityTypeBuilder<Hut> builder)
        {
            //builder.HasData(GenerateHuts());
        }

        private Hut[] GenerateHuts()
        {
            ICollection<Hut> huts = new HashSet<Hut>();

            return huts.ToArray();
        }
    }
}
