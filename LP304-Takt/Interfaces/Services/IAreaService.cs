using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAreaService : IBaseService<Area>
    {
        Task<ServiceResponse<int>> Add(Area area, int companyId);
        Task<List<Event>> GetEventsByArea(int areaId);
        Task<List<Alarm>> GetAlarmsByArea(int areaId);
        // Task<ServiceResponse<QueueDto>> GetQueueByArea(int areaId);
    }
}
