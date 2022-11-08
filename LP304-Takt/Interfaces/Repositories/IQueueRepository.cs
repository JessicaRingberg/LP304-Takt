using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IQueueRepository
    {
        Task<ICollection<Queue>> GetAllQueues();
        Task<Queue?> GetOneQueue(int queueId);
        Task<ServiceResponse<int>> DeleteOrderFromQueue(int areaId, int orderId);
        Task<Area?> GetQueueFromArea(int areaId);
    }
}
