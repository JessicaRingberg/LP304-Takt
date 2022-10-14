using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task<ServiceResponse<int>> Add(Area area, int companyId);
        Task<Area?> GetEventsFromArea(int id);


    }
}
