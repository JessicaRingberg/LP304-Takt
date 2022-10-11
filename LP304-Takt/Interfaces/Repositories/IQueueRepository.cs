using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IQueueRepository : IBaseRepository<Queue>
    {
        Task<ServiceResponse<int>> DeleteOrderFromQueue(int areaId, int orderId);
    }
}
