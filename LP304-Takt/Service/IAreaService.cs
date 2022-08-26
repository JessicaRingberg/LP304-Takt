using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAreas();
        Task<Area> GetOneArea(int id);
        Task AddArea(Area area);
        Task RemoveArea(Area area);
    }
}
