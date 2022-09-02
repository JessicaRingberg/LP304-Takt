using System.Collections;
using System.Linq.Expressions;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task <T>GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Remove(T entity);
        Task<T> Update(T entity);

    }
}
