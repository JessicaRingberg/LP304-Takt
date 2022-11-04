using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IQueueService
    {
        Task<ICollection<Queue>> GetAllQueues();
        Task<Queue?> GetOneQueue(int id);
        Task<ServiceResponse<int>> DeleteOrderFromQueue(int areaId, int orderId);
        Task<Area?> GetQueueFromArea(int areaId);
    }
}
