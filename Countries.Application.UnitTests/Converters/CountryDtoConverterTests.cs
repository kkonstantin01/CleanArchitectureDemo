using Xunit;
using Countries.Application.Converters;
using Countries.Application.Dtos;
using Countries.Domain.Entities;

namespace Countries.Application.UnitTests.Converters
{
    public class CountryDtoConverterTests 
    {
        [Fact]
        public void ConvertEntityToDto()
        {
            // Arrange
            var entity = new Country
            {
                Id = 1,
                Name = "Germany"
            };

            var converter = new CountryDtoConverter();

            // Act
            CountryDto dto = converter.Map(entity);

            // Assert
            Assert.Equal("Germany", dto.Name);
        }
    }
}
