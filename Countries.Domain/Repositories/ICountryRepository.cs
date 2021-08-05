using Countries.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.Domain.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<IEnumerable<Country>> GetCountryByName(string name);
    }
}
