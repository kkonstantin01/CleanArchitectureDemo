using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnsureThat;
using Countries.Domain.Entities;
using Countries.Domain.Repositories;

namespace Countries.Application.UseCases.Countries.Commands
{
    public class CreateCountryHandler : IRequestHandler<CreateCountry, Country>
    {
        private readonly ICountryRepository _repository;

        public CreateCountryHandler(ICountryRepository repository)
        {
            EnsureArg.IsNotNull(repository, nameof(repository));

            _repository = repository;
        }

        public async Task<Country> Handle(CreateCountry request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Item);
        }
    }
}
