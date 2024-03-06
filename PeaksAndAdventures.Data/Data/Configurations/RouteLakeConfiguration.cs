using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RouteLakeConfiguration : IEntityTypeConfiguration<RouteLake>
    {
        public void Configure(EntityTypeBuilder<RouteLake> builder)
        {
            builder.HasKey(rl => new
            {
                rl.RouteId, rl.LakeId
            });

            builder
                .HasOne(rl => rl.Lake)
                .WithMany(l => l.RoutesLakes)
                .HasForeignKey(rl => rl.LakeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(rl => rl.Route)
                .WithMany(r => r.RoutesLakes)
                .HasForeignKey(rl => rl.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
