using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(LP304Context context) : base(context)
        {

        }
    }
}
