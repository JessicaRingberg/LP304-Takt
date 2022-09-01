using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        Task AddStation(Station station, int id);
        Task<IEnumerable<Station>> GetAllStations();
    }
}
