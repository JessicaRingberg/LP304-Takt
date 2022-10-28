using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IStationRepository : IBaseRepository<Station>
    {
        Task<ServiceResponse<int>> Add(Station station, int areaId);      
    }
}
