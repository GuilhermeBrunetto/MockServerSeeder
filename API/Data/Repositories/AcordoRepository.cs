using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class AcordoRepository : BaseRepository<Acordo>, IAcordoRepository
    {
        public AcordoRepository(DataContext context) : base(context)
        {
        }

        public async Task<ICollection<Acordo>> GetAcordosByProdutoAsync(int produtoId)
        {
            return await _context.Acordos.Where(deal => deal.ProdutoId == produtoId)
                .ToListAsync();
        }
    }
}