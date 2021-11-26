using Xunit;
using Countries.Domain.Entities;

namespace Countries.Domain.UnitTests.Entities
{
    public class CountryTests
    {
        [Fact]
        public void CountryTest() 
        {
            // Arrange
            var entity = new Country
            {
                Id = 1,
                Name = "Germany"
            };

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal("Germany", entity.Name);
        }
    }
}
