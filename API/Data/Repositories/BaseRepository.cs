using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<bool> UpdateAsync(T updatedEntity)
        {
            _context.Set<T>().Update(updatedEntity);
            await _context.SaveChangesAsync();
            return true;
        }
 
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
 
    }
}