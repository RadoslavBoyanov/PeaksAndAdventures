using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeaksAndAdventures.Infrastructure.Data.Models;

namespace PeaksAndAdventures.Infrastructure.Data.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            //builder.HasData(GenerateRoutes());
        }

        private Route[] GenerateRoutes()
        {
            ICollection<Route> routes =  new HashSet<Route>();

            return routes.ToArray();
        }
    }
}
