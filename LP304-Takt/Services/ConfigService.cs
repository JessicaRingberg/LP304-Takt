﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public async Task Add(Config config, int areaId)
        {
            await _configRepository.Add(config, areaId);
        }

        public async Task DeleteEntity(int id)
        {
            await _configRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Config>> GetEntities()
        {
            return await _configRepository.GetEntities();
        }

        public async Task<Config?> GetEntity(int id)
        {
            return await _configRepository.GetEntity(id);
        }

        public async Task UpdateEntity(Config config, int configId)
        {
            await _configRepository.UpdateEntity(config, configId);
        }
    }
}
