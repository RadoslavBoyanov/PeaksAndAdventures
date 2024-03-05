using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class LakeConfiguration : IEntityTypeConfiguration<Lake>
    {
        public void Configure(EntityTypeBuilder<Lake> builder)
        {
            builder.HasData(GenerateLakes());
        }

        private Lake[] GenerateLakes()
        {
            ICollection<Lake> lakes = new HashSet<Lake>();

            return lakes.ToArray();
        }
    }
}
