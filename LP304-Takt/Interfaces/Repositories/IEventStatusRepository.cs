using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IEventStatusRepository : IBaseRepository<EventStatus>
    {
        Task<ServiceResponse<EventStatus>> Add(EventStatus eventStatus);        
    }
}
