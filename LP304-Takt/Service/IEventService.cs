using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> GetOneEvent(int id);
        Task AddEvent(Event eEvent);
        Task RemoveEvent(Event eEvent);
        Task<Event> UpdateEvent(Event eEvent);
        Task DeleteById(int id);
    }
}
