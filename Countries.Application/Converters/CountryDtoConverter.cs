using System.Collections.Generic;
using System.Linq;
using Countries.Application.Dtos;
using Countries.Domain.Entities;

namespace Countries.Application.Converters
{
    public class CountryDtoConverter : ITypeConverter<Country, CountryDto>
    {
        public CountryDto Map(Country source)
        {
            if (source == null)
            {
                return null;
            }

            return new CountryDto
            {
                Name = source.Name
            };
        }

        public IEnumerable<CountryDto> Map(IEnumerable<Country> sources)
        {
            return sources?.Select(Map);
        }
    }
}
