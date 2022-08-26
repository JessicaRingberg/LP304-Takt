using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class QueueService : IQueueService
    {
        private readonly IUnitOfWork _queueUnitOfWork;

        public QueueService(IUnitOfWork queueUnitOfWork)
        {
            _queueUnitOfWork = queueUnitOfWork;
        }
        public async Task AddQueue(Queue queue)
        {
            await _queueUnitOfWork.Queues.Add(queue);
        }

        public async Task<IEnumerable<Queue>> GetAllQueues()
        {
            return await _queueUnitOfWork.Queues.GetAll();
        }

        public async Task<Queue> GetOneQueue(int id)
        {
            return await _queueUnitOfWork.Queues.GetById(id);
        }

        public async Task RemoveQueue(Queue queue)
        {
            await _queueUnitOfWork.Queues.Remove(queue);
        }

        public async Task<Queue> UpdateQueue(Queue queue)
        {
            return await _queueUnitOfWork.Queues.Update(queue);
        }
    }
}
