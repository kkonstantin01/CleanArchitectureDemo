using Countries.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Countries.Application.UseCases.Countries.Queries
{
    public class ReadCountries : IRequest<IEnumerable<Country>>
    {
    }
}
