using MediatR;
using Countries.Domain.Entities;

namespace Countries.Application.UseCases.Countries.Commands
{
    public class CreateCountry : IRequest<Country>
    {
        public CreateCountry(Country item)
        {
            Item = item;
        }

        public Country Item { get; set; }
    }
}