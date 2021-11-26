using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Countries.Application.UseCases.Countries.Queries;
using Countries.Domain.Entities;
using Countries.Domain.Repositories;

namespace Countries.Application.UnitTests.UseCases.Countries.Queries
{
    public class ReadCountriesHandlerTests
    {
        [Fact]
        public async Task HandlerReturnsValidResult()
        {
            // Arrange
            var request = new ReadCountries();

            var mediator = new Mock<ICountryRepository>();
            var handler = new ReadCountriesHandler(mediator.Object);

            // Act
            IEnumerable<Country> result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Country>>(result);
        }

        [Fact]
        public void HandlerThrowsException()
        {
            // Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new ReadCountriesHandler(null));
            Assert.Equal("Value can not be null. (Parameter 'repository')", exception.Message);
        }
    }
}