using System.Collections;
using System.Linq.Expressions;

namespace LP304_Takt.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task <T>GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Remove(T entity);
        Task<T> Update(T entity);

        Task DeleteAsync(int id);
        // Task <IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        //Task AddRange(IEnumerable<T> entities);

        // Task RemoveRange(IEnumerable<T> entities);
    }
}
