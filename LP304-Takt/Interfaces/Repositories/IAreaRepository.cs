using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task<ServiceResponse<Area>> Add(Area area, int companyId);
        Task<List<Event>> GetEventsByArea(int areaId);
        Task<List<Alarm>> GetAlarmsByArea(int areaId);
        Task<User?> GetAreaByUser(int userId);
    }
}
