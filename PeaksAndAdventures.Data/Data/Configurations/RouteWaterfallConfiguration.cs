using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RouteWaterfallConfiguration : IEntityTypeConfiguration<RouteWaterfall>
    {
        public void Configure(EntityTypeBuilder<RouteWaterfall> builder)
        {
            builder
                .HasKey(rw => new
                {
                    rw.RouteId,
                    rw.WaterfallId
                });

            builder
                .HasOne(rw => rw.Route)
                .WithMany(r => r.RoutesWaterfalls)
                .HasForeignKey(r => r.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(rw => rw.Waterfall)
                .WithMany(w => w.RoutesWaterfalls)
                .HasForeignKey(w => w.WaterfallId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
