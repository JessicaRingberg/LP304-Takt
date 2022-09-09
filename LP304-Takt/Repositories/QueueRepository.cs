using LP304_Takt.Interfaces.Repositories;
using System.Collections;

namespace LP304_Takt.Repositories
{
    public class QueueRepository : IQueueRepository
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
