using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IAcordoRepository : IRepository<Acordo>
    {
        Task<ICollection<Acordo>> GetAcordosByProdutoAsync(int graoId);
    }
}