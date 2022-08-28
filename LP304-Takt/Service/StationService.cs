using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class StationService : IStationService
    {
        private readonly IUnitOfWork _stationUnitOfWork;

        public StationService(IUnitOfWork stationUnitOfWork)
        {
            _stationUnitOfWork = stationUnitOfWork;
        }
        public async Task AddStation(Station station)
        {
            await _stationUnitOfWork.Stations.Add(station);
        }

        public async Task DeleteById(int id)
        {
            var station = await _stationUnitOfWork.Stations.GetById(id);
            await _stationUnitOfWork.Stations.Remove(station);
            _stationUnitOfWork.Complete();

        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _stationUnitOfWork.Stations.GetAll();
        }

        public async Task<Station> GetOneStation(int id)
        {
            return await _stationUnitOfWork.Stations.GetById(id);
        }

        public async Task RemoveStation(Station station)
        {
            await _stationUnitOfWork.Stations.Remove(station);
        }

        public async Task<Station> UpdateStation(Station station)
        {
            return await _stationUnitOfWork.Stations.Update(station);
        }
    }
}
