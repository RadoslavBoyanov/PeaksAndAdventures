using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RoutePeakConfiguration : IEntityTypeConfiguration<RoutePeak>
    {
        public void Configure(EntityTypeBuilder<RoutePeak> builder)
        {
            builder.HasKey(rp => new
            {
                rp.RouteId, rp.PeakId
            });

            builder.HasOne(rp => rp.Peak)
                .WithMany(rp => rp.RoutesPeaks)
                .HasForeignKey(rp => rp.PeakId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rp => rp.Route)
                .WithMany(rp => rp.RoutesPeaks)
                .HasForeignKey(rp => rp.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
