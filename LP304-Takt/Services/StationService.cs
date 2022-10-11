﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class StationService : IStationService
    {
        readonly IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<ServiceResponse<int>> Add(Station station, int areaId)
        {
            return await _stationRepository.Add(station, areaId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            return await _stationRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Station>> GetEntities()
        {
            return await _stationRepository.GetEntities();
        }

        public async Task<Station?> GetEntity(int id)
        {
            return await _stationRepository.GetEntity(id);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Station station, int stationId)
        {
            return await _stationRepository.UpdateEntity(station, stationId);
        }
    }
}
