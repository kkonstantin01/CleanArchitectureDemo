using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Countries.Domain.Entities;

namespace Countries.Infrastructure.Persistence
{
    [ExcludeFromCodeCoverage]
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base (options)
        {

        }

        public DbSet<Country> Countries { get; set; }
    }
}
