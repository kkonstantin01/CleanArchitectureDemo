using System.Collections.Generic;
using System.Threading.Tasks;
using Countries.Domain.Entities;

namespace Countries.Domain.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<IEnumerable<Country>> GetCountryByName(string name);
    }
}
