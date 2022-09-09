using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task Add(Area area, int companyId);
        Task UpdateArea(Area area, int areaId);
    }
}
