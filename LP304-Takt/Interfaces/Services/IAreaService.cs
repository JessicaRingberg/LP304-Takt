using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAreaService : IBaseService<Area>
    {
        Task Add(Area area, int companyId);
        //Task UpdateArea(Area area, int areaId);
    }
}
