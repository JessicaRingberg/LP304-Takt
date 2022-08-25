using System.Linq.Expressions;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LP304Context _context;
        public GenericRepository(LP304Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.

        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
           // await _context.SaveChangesAsync();
        }
        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        //public void AddRange(IEnumerable<T> entities)
        //{
        //    _context.Set<T>().AddRange(entities);
        //}

        //public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        //{
        //    return _context.Set<T>().Where(expression);
        //}


        //public async Task RemoveRange(IEnumerable<T> entities)
        //{
        //   return await _context.Set<T>().RemoveRange(entities);
        //}
    }
}
