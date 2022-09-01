﻿using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAllStations();
        Task<Station> GetOneStation(int id);
        Task AddStation(Station station, int id);
        Task RemoveStation(Station station);
        Task<Station> UpdateStation(Station station);
        Task DeleteById(int id);
    }
}
