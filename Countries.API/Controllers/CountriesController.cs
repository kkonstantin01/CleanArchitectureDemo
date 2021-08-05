﻿using Countries.Application.Converters;
using Countries.Application.Dtos;
using Countries.Application.UseCases.Countries.Commands;
using Countries.Application.UseCases.Countries.Queries;
using Countries.Domain.Entities;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Countries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            EnsureArg.IsNotNull(mediator, nameof(mediator));

            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new ReadCountries();

            IEnumerable<Country> entities = await _mediator.Send(query, cancellationToken);

            IEnumerable<CountryDto> result = entities.Map();

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

            Country entity = item.Map();

            var command = new CreateCountry(entity);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}