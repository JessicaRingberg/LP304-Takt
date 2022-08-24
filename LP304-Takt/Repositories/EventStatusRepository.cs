using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class EventStatusRepository : GenericRepository<EventStatus>, IEventStatusRepository
    {
        public EventStatusRepository(LP304Context context) : base(context)
        {

        }
    }
}
