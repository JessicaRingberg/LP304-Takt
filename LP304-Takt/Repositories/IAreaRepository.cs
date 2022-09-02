using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
       Task AddArea(Area area, int id);
       Task <IEnumerable<Area>> GetAllAreas();
       Task<Area> GetOneArea(int id);
       Task RemoveArea(Area area);

    }
}
