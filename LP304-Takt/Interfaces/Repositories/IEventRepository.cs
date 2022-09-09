using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task Add(Event eEvent, int orderId, int eventStatusId);
        Task UpdateEvent(Event eEvent, int eventId);
    }
}
