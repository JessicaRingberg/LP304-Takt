using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAreaService : IBaseService<Area>
    {
        Task<ServiceResponse<int>> Add(Area area, int companyId);
        Task<ICollection<Event?>> GetEventsByArea(int areaId);

    }
}
