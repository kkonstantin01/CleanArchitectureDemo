using Microsoft.EntityFrameworkCore;
using Countries.Domain.Entities;

namespace Countries.Infrastructure.Persistence
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base (options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
