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

            builder.HasData(GenerateMountaineerRoutes());
        }

        private MountaineerRoute[] GenerateMountaineerRoutes()
        {
            ICollection<MountaineerRoute> mountaineerRoutes = new HashSet<MountaineerRoute>();

            mountaineerRoutes.Add(new MountaineerRoute()
            {
                RouteId = 2,
                MountainGuideId = 1
            });

            mountaineerRoutes.Add(new MountaineerRoute()
            {
                RouteId = 5,
                MountainGuideId = 1
            });

            mountaineerRoutes.Add(new MountaineerRoute()
            {
                RouteId = 8,
                MountainGuideId = 1
            });

            return mountaineerRoutes.ToArray();
        }
    }
}
