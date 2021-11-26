using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MediatR;
using Countries.API.Controllers;
using Countries.Application.Converters;
using Countries.Application.Dtos;
using Countries.Domain.Entities;

namespace Countries.API.UnitTests.Controllers
{
    public class CountriesControllerTests
    {
        [Fact]
        public async Task GetTest() 
        {
            // Arrange
            var mediator = new Mock<IMediator>();

            var converter = new Mock<ITypeConverter<CountryDto, Country>>();
            var dtoConverter = new Mock<ITypeConverter<Country, CountryDto>>();
            dtoConverter.Setup(s => s.Map(It.IsAny<IEnumerable<Country>>())).Returns(new List<CountryDto>());

            var controller = new CountriesController(mediator.Object, converter.Object, dtoConverter.Object);

            // Act
            IActionResult actionResult = await controller.Get(new CancellationToken());

            // Assert
            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);

            var result = (actionResult as OkObjectResult).Value as List<CountryDto>;
            Assert.NotNull(result);
        }
    }
}
