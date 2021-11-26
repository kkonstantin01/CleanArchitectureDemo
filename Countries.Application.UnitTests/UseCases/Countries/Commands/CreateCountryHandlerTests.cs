using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Countries.Application.UseCases.Countries.Commands;
using Countries.Domain.Entities;
using Countries.Domain.Repositories;

namespace Countries.Application.UnitTests.UseCases.Countries.Commands
{
    public class CreateCountryHandlerTests
    {
        [Fact]
        public async Task CreateCountryHandlerValidResult() 
        {
            // Arrange
            var country = new Country { Id = 1, Name = "Germany" };

            var request = new CreateCountry(country);

            var repository = new Mock<ICountryRepository>();
            repository.Setup(s => s.AddAsync(It.IsAny<Country>())).ReturnsAsync(country);

            var handler = new TestCreateCountryHandler(repository.Object);

            // Act
            Country result = await handler.Execute(request, new CancellationToken());

            Assert.Equal(1, result.Id);
            Assert.Equal("Germany", result.Name);
        }

        [Fact]
        public void CreateCountryHandlerThrowsException()
        {
            // Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new TestCreateCountryHandler(null));
            Assert.Equal("Value can not be null. (Parameter 'repository')", exception.Message);
        }

        private class TestCreateCountryHandler : CreateCountryHandler 
        {
            public TestCreateCountryHandler(ICountryRepository repository) : base(repository)
            {
            }

            public async Task<Country> Execute(CreateCountry request, CancellationToken cancellationToken)
            {
                return await base.Handle(request, cancellationToken);
            }
        }
    }
}