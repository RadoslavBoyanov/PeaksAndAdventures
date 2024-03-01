using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PeaksAndAdventures.Infrastructure
{
    public class PeaksAndAdventuresDbContext : IdentityDbContext
    {
        public PeaksAndAdventuresDbContext(DbContextOptions<PeaksAndAdventuresDbContext> options)
            : base(options)
        {
        }
    }
}
