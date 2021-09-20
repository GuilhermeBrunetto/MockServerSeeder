using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T updatedEntity);
        Task<bool> DeleteAsync(int id);
    }
}