using System.Diagnostics.CodeAnalysis;
using Xunit;
using Countries.Application.Converters;
using Countries.Application.Dtos;
using Countries.Domain.Entities;

namespace Countries.Application.UnitTests.Converters
{
    [ExcludeFromCodeCoverage]
    public class CountryConverterTests
    {
        [Fact]
        public void ConvertDtoToEntity()
        {
            // Arrange
            var dto = new CountryDto
            {
                Name = "Germany"
            };

            var converter = new CountryConverter();

            // Act
            Country entity = converter.Map(dto);

            // Assert
            Assert.Equal("Germany", entity.Name);
        }
    }
}
