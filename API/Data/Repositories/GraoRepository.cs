using API.Entities;
using API.Interfaces;

namespace API.Data.Repositories
{
    public class GraoRepository : BaseRepository<Grao>, IGraoRepository
    {
        public GraoRepository(DataContext context) : base(context)
        {
        }
    }
}