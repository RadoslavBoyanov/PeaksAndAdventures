using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class MountaineerMountainConfigure : IEntityTypeConfiguration<MountaineerMountain>
    {
        public void Configure(EntityTypeBuilder<MountaineerMountain> builder)
        {
            builder
                .HasKey(mm => new
                {
                    mm.MountainGuideId, mm.MountainId
                });

            builder
                .HasOne(mm => mm.Mountain)
                .WithMany(m => m.MountaineersMountains)
                .HasForeignKey(mm => mm.MountainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(mm => mm.MountainGuide)
                .WithMany(m => m.MountaineersMountains)
                .HasForeignKey(mm => mm.MountainGuideId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
