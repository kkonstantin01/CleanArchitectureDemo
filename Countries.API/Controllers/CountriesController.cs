using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnsureThat;
using MediatR;
using Countries.Application.Converters;
using Countries.Application.Dtos;
using Countries.Application.UseCases.Countries.Commands;
using Countries.Application.UseCases.Countries.Queries;
using Countries.Domain.Entities;

namespace Countries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITypeConverter<CountryDto, Country> _converter;
        private readonly ITypeConverter<Country, CountryDto> _dtoConverter;

        public CountriesController(IMediator mediator, ITypeConverter<CountryDto, Country> converter, ITypeConverter<Country, CountryDto> dtoConverter)
        {
            EnsureArg.IsNotNull(mediator, nameof(mediator));
            EnsureArg.IsNotNull(mediator, nameof(converter));
            EnsureArg.IsNotNull(mediator, nameof(dtoConverter));

            _mediator = mediator;
            _converter = converter;
            _dtoConverter = dtoConverter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new ReadCountries();

            IEnumerable<Country> entities = await _mediator.Send(query, cancellationToken);

            IEnumerable<CountryDto> result = _dtoConverter.Map(entities);

            return Ok(result);
        }
              
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryDto>> Post([FromBody] CountryDto item, CancellationToken cancellationToken)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Country entity = _converter.Map(item);

            var command = new CreateCountry(entity);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}