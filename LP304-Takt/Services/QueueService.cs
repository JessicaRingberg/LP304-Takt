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

        public Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Queue>> GetEntities()
        {
            return await _queueRepository.GetEntities();
        }

        public async Task<Queue?> GetEntity(int id)
        {
            return await _queueRepository.GetEntity(id);
        }

        public Task<ServiceResponse<int>> UpdateEntity(Queue entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
