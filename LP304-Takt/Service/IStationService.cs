using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAllStations();
        Task<Station> GetOneStation(int id);
        Task AddStation(Station station);
        Task RemoveStation(Station station);
        Task<Station> UpdateStation(Station station);
    }
}
