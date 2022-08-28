using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IEventStatusService
    {
        Task<IEnumerable<EventStatus>> GetAllEventStatuses();
        Task<EventStatus> GetOneEventStatus(int id);
        Task AddEventStatus(EventStatus eventStatus);
        Task RemoveEventStatus(EventStatus eventStatus);
        Task<EventStatus> UpdateEventStatus(EventStatus eventStatus);
        Task DeleteById(int id);
    }
}
