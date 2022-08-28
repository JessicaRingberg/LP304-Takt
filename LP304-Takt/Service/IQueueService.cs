using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IQueueService
    {
        Task<IEnumerable<Queue>> GetAllQueues();
        Task<Queue> GetOneQueue(int id);
        Task AddQueue(Queue queue);
        Task RemoveQueue(Queue queue);
        Task<Queue> UpdateQueue(Queue queue);
        Task DeleteById(int id);
    }
}
