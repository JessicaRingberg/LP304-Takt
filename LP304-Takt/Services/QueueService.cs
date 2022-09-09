using LP304_Takt.Interfaces.Services;
using System.Collections;

namespace LP304_Takt.Services
{
    public class QueueService : IQueueService
    {
        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Queue>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Queue?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Queue entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
