using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Infrastructure.Data.Models;
using System.Reflection;

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

        public DbSet<Rating> Ratings { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public DbSet<RouteHut> RoutesHuts { get; set; } = null!;

        public DbSet<RouteLake> RoutesLakes { get; set; } = null!;

        public DbSet<RoutePeak> RoutesPeaks { get; set; } = null!;

        public DbSet<RouteWaterfall> RoutesWaterfalls { get; set; } = null!;

        public DbSet<TourAgency> TourAgencies { get; set; } = null!;

        public DbSet<Waterfall> Waterfalls { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            Assembly configAssembly =
                Assembly.GetAssembly(typeof(PeaksAndAdventuresDbContext)) ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}
