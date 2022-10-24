using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _queueRepository;

        public QueueService(IQueueRepository queueRepository)
        {
            _queueRepository = queueRepository;
        }

        public async Task<ServiceResponse<int>> DeleteOrderFromQueue(int areaId, int orderId)
        {
            return await _queueRepository.DeleteOrderFromQueue(areaId, orderId);
        }

        public async Task<ICollection<Queue>> GetAllQueues()
        {
            return await _queueRepository.GetAllQueues();
        }

        public async Task<Queue?> GetOneQueue(int id)
        {
            return await _queueRepository.GetOneQueue(id);
        }
    }
}
