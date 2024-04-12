using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeaksAndAdventures.Core.Interfaces;
using PeaksAndAdventures.Core.Services;
using PeaksAndAdventures.Infrastructure.Data;
using PeaksAndAdventures.Infrastructure.Data.Common;

namespace PeaksAndAdventures.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
	        services.AddScoped<IMountainService, MountainService>();
            services.AddScoped<IPeakService, PeakService>();
            services.AddScoped<IHutService, HutService>();
            services.AddScoped<ILakeService, LakeService>();
            services.AddScoped<IWaterfallService, WaterfallService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IExpeditionService, ExpeditionService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ITourAgencyService, TourAgencyService>();
            services.AddScoped<IMountainGuideService, MountainGuideService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<PeaksAndAdventuresDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PeaksAndAdventuresDbContext>();

            return services;
        }
    }
}
