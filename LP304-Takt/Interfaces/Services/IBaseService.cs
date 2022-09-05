namespace LP304_Takt.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<ICollection<T>> GetEntities();
        Task<T> GetEntity(int id);
        Task DeleteEntity(int id);
        Task UpdateEntity(T entity);
    }
}
