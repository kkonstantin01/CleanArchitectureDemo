using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Countries.Domain.Entities;
using Countries.Domain.Repositories;
using Countries.Infrastructure.Persistence;

namespace Countries.Infrastructure.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(CountryContext countryContext) : base(countryContext)
        {

        }

        public async Task<IEnumerable<Country>> GetCountryByName(string name)
        {
            return await _countryContext.Countries
                .Where(m => m.Name == name)
                .ToListAsync();
        }
    }
}
