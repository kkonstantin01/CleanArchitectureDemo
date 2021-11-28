using System.Diagnostics.CodeAnalysis;
using Xunit;
using Countries.Application.Dtos;

namespace Countries.Application.UnitTests.Dtos
{
    [ExcludeFromCodeCoverage]
    public class CountryDtoTests
    {
        [Fact]
        public void CountryDtoTest()
        {
            // Arrange
            var entity = new CountryDto
            {
                Name = "Germany"
            };

            // Assert
            Assert.Equal("Germany", entity.Name);
        }
    }
}
