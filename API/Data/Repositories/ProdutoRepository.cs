using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext context) : base(context)
        {
        }

        public Task<Acordo> AddAcordo(int produtoId, Acordo acordo)
        {
            // from produto in _context.Produtos
            //     where 

            throw new System.NotImplementedException();
        }
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            // Retorna o Produto Incluindo seu array de Acordos
            IQueryable<Produto> query = _context.Produtos
                     .Include(prod => prod.Acordos)
                ;

            // Inclui seu array de Territorios
            query = query.Include(prod => prod.Territorios)
                .ThenInclude(terr => terr.Territorio);

            query = query.AsNoTracking().OrderBy(p => p.ProdutoId);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(prod => prod.Acordos);

            query = query.Include(prod => prod.Territorios)
                .ThenInclude(terr => terr.Territorio);

            query = query.AsNoTracking().OrderBy(p => p.ProdutoId);

            return await query.FirstOrDefaultAsync(prod => prod.ProdutoId == id);
        }

        public Task<bool> RemoveAcordo(int acordoId)
        {
            throw new System.NotImplementedException();
        }
    }
}