using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IEventStatusRepository : IBaseRepository<EventStatus>
    {
        Task Add(EventStatus eventStatus);
        //Task UpdateEventStatus(EventStatus eventStatus, int eventStatusId);
    }
}
