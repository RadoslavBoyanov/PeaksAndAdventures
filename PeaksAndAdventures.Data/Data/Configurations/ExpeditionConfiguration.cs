using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class ExpeditionConfiguration : IEntityTypeConfiguration<Expedition>
    {
        public void Configure(EntityTypeBuilder<Expedition> builder)
        {
            //builder.HasData(GenerateMountainGuide());
        }
    }
}
