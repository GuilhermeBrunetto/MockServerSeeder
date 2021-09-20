using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> AddGrao(int produtoId, Grao grao);
        Task<bool> RemoveGrao(int produtoId, int graoId);
    }
}