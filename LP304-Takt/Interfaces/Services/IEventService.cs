using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IEventService : IBaseService<Event>
    {
        Task<ServiceResponse<int>> Add(Event eEvent, int orderId, int eventStatusId);
        
    }
}
