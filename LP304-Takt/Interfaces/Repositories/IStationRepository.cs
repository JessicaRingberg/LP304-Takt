using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IStationRepository : IBaseRepository<Station>
    {
        Task Add(Station station, int areaId);
        Task UpdateStation(Station station, int stationId);
    }
}
