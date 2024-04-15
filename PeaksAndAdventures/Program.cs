using PeaksAndAdventures.Extensions;
using PeaksAndAdventures.ModelBinders;

namespace PeaksAndAdventures
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
	        
            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);
            
            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
            });
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
				app.UseExceptionHandler("/Home/Error/500");
				app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
				app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{

				// Тук добави маршрути за административната област

				endpoints.MapControllerRoute(
					name: "Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
	                name: "default",
	                pattern: "{controller=Home}/{action=Index}/{id?}");

				endpoints.MapRazorPages();
			});

			await app.ConfigureRolesAndAdmin();

            await app.RunAsync();
        }
    }
}