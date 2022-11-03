using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task<ServiceResponse<int>> Add(Area area, int companyId);
        Task<List<Event>> GetEventsFromArea(int areaId);
        Task<List<Alarm>> GetAlarmsFromArea(int areaId);
    }
}
