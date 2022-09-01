using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAreas();
        Task<IEnumerable<Area>> GetAllAreas();
        //Task <IEnumerable<Area>?> GetAllAreasAndCompany();
        Task<Area> GetOneArea(int id);
        Task AddArea(Area area, int id);
        Task<Area> UpdateArea(Area area);
        Task RemoveArea(Area area);
        Task DeleteById(int id);
    }
}
