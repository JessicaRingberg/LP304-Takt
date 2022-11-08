using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<ICollection<T>> GetEntities();
        Task<T?> GetEntity(int entityId);
        Task<ServiceResponse<int>> DeleteEntity(int entityId);
        Task<ServiceResponse<int>> UpdateEntity(T entity, int entityId);
    }
}
