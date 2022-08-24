using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class QueueRepository : GenericRepository<Queue>, IQueueRepository
    {
        public QueueRepository(LP304Context context) : base(context)
        {

        }
    }
}
