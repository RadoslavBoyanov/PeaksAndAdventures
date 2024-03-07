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

            //builder.HasData(GenerateRoutesPeaks());
        }

        private RoutePeak[] GenerateRoutesPeaks()
        {
           ICollection<RoutePeak> routePeaks = new HashSet<RoutePeak>();

           routePeaks.Add(new RoutePeak()
           {
               RouteId = 2,
               PeakId = 31,
           });

           routePeaks.Add(new RoutePeak()
           {
               RouteId = 1,
               PeakId = 91
           });

           routePeaks.Add(new RoutePeak()
           {
               RouteId = 6,
               PeakId = 121
           });

           routePeaks.Add(new RoutePeak()
           {
               RouteId = 7,
               PeakId = 152
           });

           routePeaks.Add(new RoutePeak()
           {
               RouteId = 8,
               PeakId = 131
           });

           return routePeaks.ToArray();
        }
    }
}
