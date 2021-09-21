using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Acordo> AddAcordo(int produtoId, Acordo acordo);
        Task<bool> RemoveAcordo(int acordoId);
    }
}