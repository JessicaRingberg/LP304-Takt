using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IQueueRepository : IBaseRepository<Queue>
    {
        Task Add(int id);
    }
}
