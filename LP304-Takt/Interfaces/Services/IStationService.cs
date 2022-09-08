using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IStationService : IBaseService<Station>
    {
        Task Add(Station station, int areaId);
        Task UpdateStation(Station station, int stationId);
    }
}
