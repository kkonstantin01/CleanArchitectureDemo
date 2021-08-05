using Countries.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
