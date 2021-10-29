using System.Collections.Generic;
using MediatR;
using Countries.Domain.Entities;

namespace Countries.Application.UseCases.Countries.Queries
{
    public class ReadCountries : IRequest<IEnumerable<Country>>
    {
    }
}
