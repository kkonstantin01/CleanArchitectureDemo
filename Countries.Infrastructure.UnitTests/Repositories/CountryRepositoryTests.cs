using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Countries.Domain.Entities;
using Countries.Infrastructure.Persistence;
using Countries.Infrastructure.Repositories;

namespace Countries.Infrastructure.UnitTests.Repositories
{
    public class CountryRepositoryTests
    {
        [Fact]
        public async Task GetReturnsValidResult() 
        {
            // Arrange
            var dbContextOptions = CreateDbContextOptions();

            var context = await Seed(dbContextOptions, new CancellationToken());

            var repository = new CountryRepository(context);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);

            Country country = result.First();

            Assert.Equal(1, country.Id);
            Assert.Equal("Germany", country.Name);
        }

        private static async Task<CountryContext> Seed(DbContextOptions<CountryContext> dbContextOptions, CancellationToken cancellationToken) 
        {
            var context = new CountryContext(dbContextOptions);

            await context.Database.EnsureDeletedAsync(cancellationToken);

            var country = new Country { Id = 1, Name = "Germany" };

            await context.Countries.AddAsync(country, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return context;
        }

        private static DbContextOptions<CountryContext> CreateDbContextOptions()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CountryContext>();

            dbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            dbContextOptions.EnableSensitiveDataLogging();

            dbContextOptions.UseInMemoryDatabase(Guid.NewGuid().ToString());

            return dbContextOptions.Options;
        }
    }
}