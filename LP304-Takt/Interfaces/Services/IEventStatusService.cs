using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IEventStatusService : IBaseService<EventStatus>
    {
        Task<ServiceResponse<int>> Add(EventStatus eventStatus);
       
    }
}
