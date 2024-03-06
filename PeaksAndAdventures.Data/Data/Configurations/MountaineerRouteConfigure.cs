using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class MountaineerRouteConfigure : IEntityTypeConfiguration<MountaineerRoute>
    {
        public void Configure(EntityTypeBuilder<MountaineerRoute> builder)
        {
            builder
                .HasKey(mr => new
                {
                    mr.RouteId, mr.MountainGuideId
                });

            builder
                .HasOne(mr => mr.Route)
                .WithMany(r => r.MountaineersRoutes)
                .HasForeignKey(mr => mr.RouteId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(mr => mr.MountainGuide)
                .WithMany(m => m.MountaineersRoutes)
                .HasForeignKey(mr => mr.MountainGuideId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
