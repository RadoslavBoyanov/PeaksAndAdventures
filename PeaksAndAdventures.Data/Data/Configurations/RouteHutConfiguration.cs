using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RouteHutConfiguration : IEntityTypeConfiguration<RouteHut>
    {
        public void Configure(EntityTypeBuilder<RouteHut> builder)
        {
            builder
                .HasKey(rh => new
                {
                    rh.RouteId,
                    rh.HutId
                });

            builder
                .HasOne(rh => rh.Hut)
                .WithMany(h => h.RoutesHuts)
                .HasForeignKey(rh => rh.HutId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(rh => rh.Route)
                .WithMany(r => r.RoutesHuts)
                .HasForeignKey(rh => rh.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
