using API.Entities;
using API.Interfaces;

namespace API.Data.Repositories
{
    public class AcordoRepository : BaseRepository<Acordo>, IAcordoRepository
    {
        public AcordoRepository(DataContext context) : base(context)
        {
        }
    }
}