using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class TerritorioRepository : BaseRepository<Territorio>, ITerritorioRepository 
    {

        public TerritorioRepository(DataContext context) : base (context)
        {

        }

        public async Task<IEnumerable<Territorio>> GetTerritorios()
        {
            IQueryable<Territorio> query = _context.Territorios
                .Include(terr => terr.Produtos);

            query = query.AsNoTracking().OrderBy(t => t.TerritorioId);

            return await query.ToArrayAsync();
        }
    }
}