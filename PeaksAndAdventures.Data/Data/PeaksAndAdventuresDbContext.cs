using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data
{
    public class PeaksAndAdventuresDbContext : IdentityDbContext
    {
        public PeaksAndAdventuresDbContext(DbContextOptions<PeaksAndAdventuresDbContext> options)
            : base(options)
        {

        }


        public DbSet<Article> Articles { get; set; } = null!;

        public DbSet<Expedition> Expeditions { get; set; } = null!;

        public DbSet<ExpeditionParticipant> ExpeditionsParticipants { get; set; } = null!;

        public DbSet<Hut> Huts { get; set; } = null!;

        public DbSet<Lake> Lakes { get; set; } = null!;
        
        public DbSet<Mountain> Mountains { get; set; } = null!;

        public DbSet<MountaineerMountain> MountaineersMountains { get; set; } = null!;

        public DbSet<MountaineerRoute> MountaineersRoutes { get; set; } = null!;

        public DbSet<MountainGuide> MountainGuides { get; set; } = null!;

        public DbSet<Peak> Peaks { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public DbSet<RouteHut> RoutesHuts { get; set; } = null!;

        public DbSet<RouteLake> RoutesLakes { get; set; } = null!;

        public DbSet<RoutePeak> RoutesPeaks { get; set; } = null!;

        public DbSet<RouteWaterfall> RoutesWaterfalls { get; set; } = null!;

        public DbSet<TourAgency> TourAgencies { get; set; } = null!;

        public DbSet<TourAgencyExpedition> TourAgenciesExpeditions { get; set; } = null!;

        public DbSet<Waterfall> Waterfalls { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ExpeditionParticipant>()
                .HasKey(ep => new
                {
                    ep.ExpeditionId, ep.ParticipantId
                });

            builder.Entity<MountaineerMountain>()
                .HasKey(mm => new
                {
                    mm.MountainGuideId, mm.MountainId
                });

            builder.Entity<MountaineerRoute>()
                .HasKey(mr => new
                {
                    mr.RouteId, mr.MountainGuideId
                });

            builder.Entity<RouteHut>()
                .HasKey(rh => new
                {
                    rh.RouteId, rh.HutId
                });

            builder.Entity<RouteLake>()
                .HasKey(rl => new
                {
                    rl.RouteId, rl.LakeId
                });

            builder.Entity<RoutePeak>()
                .HasKey(rp => new
                {
                    rp.RouteId, rp.PeakId
                });
            builder.Entity<RouteWaterfall>()
                .HasKey(rw => new
                {
                    rw.RouteId, rw.WaterfallId
                });

            builder.Entity<TourAgencyExpedition>()
                .HasKey(tae => new
                {
                    tae.TourAgencyId, tae.ExpeditionId
                });

            base.OnModelCreating(builder);
        }
    }
}
