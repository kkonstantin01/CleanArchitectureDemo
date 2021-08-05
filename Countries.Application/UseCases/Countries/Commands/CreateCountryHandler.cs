using Countries.Domain.Entities;
using Countries.Domain.Repositories;
using EnsureThat;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
