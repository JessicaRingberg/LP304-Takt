using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IEventStatusService : IBaseService<EventStatus>
    {
        Task Add(EventStatus eventStatus);
       
    }
}
