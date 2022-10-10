using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<ServiceResponse<int>> Add(Event eEvent, int orderId, int eventStatusId);
        
    }
}
