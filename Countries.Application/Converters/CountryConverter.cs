using System.Collections.Generic;
using System.Linq;
using Countries.Application.Dtos;
using Countries.Domain.Entities;

namespace Countries.Application.Converters
{
    public class CountryConverter : ITypeConverter<CountryDto, Country>
    {
        public Country Map(CountryDto source)
        {
            if (source == null)
            {
                return null;
            }

            return new Country
            {
                Name = source.Name
            };
        }

        public IEnumerable<Country> Map(IEnumerable<CountryDto> sources)
        {
            return sources?.Select(Map);
        }
    }
}
