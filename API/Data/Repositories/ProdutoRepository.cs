using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;

namespace API.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }

        public Task<Acordo> AddAcordo(int produtoId, Acordo acordo)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveAcordo(int acordoId)
        {
            throw new System.NotImplementedException();
        }
    }
}