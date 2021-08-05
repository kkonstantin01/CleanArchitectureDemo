using Countries.Domain.Entities;
using Countries.Domain.Repositories;
using EnsureThat;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Countries.Application.UseCases.Countries.Queries
{
    public class ReadCountriesHandler : IRequestHandler<ReadCountries, IEnumerable<Country>>
    {
        private readonly ICountryRepository _repository;

        public ReadCountriesHandler(ICountryRepository repository)
        {
            EnsureArg.IsNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<IEnumerable<Country>> Handle(ReadCountries request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
