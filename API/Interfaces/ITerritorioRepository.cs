using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ITerritorioRepository : IRepository<Territorio>
    {
        Task<IEnumerable<Territorio>> GetTerritorios();

    }
}