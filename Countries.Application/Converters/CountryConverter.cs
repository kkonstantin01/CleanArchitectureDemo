using Countries.Application.Dtos;
using Countries.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Countries.Application.Converters
{
    public static class CountryConverter
    {
        public static Country Map(this CountryDto source)
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

        public static CountryDto Map(this Country source)
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

        public static IEnumerable<CountryDto> Map(this IEnumerable<Country> sources)
        {
            return sources?.Select(Map);
        }
    }
}
