using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public async Task<ServiceResponse<Config>> Add(Config config, int areaId)
        {
            return await _configRepository.Add(config, areaId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int configId)
        {
            return await _configRepository.DeleteEntity(configId);
        }

        public async Task<ICollection<Config>> GetEntities()
        {
            return await _configRepository.GetEntities();
        }

        public async Task<Config?> GetEntity(int configId)
        {
            return await _configRepository.GetEntity(configId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Config config, int configId)
        {
            return await _configRepository.UpdateEntity(config, configId);
        }
    }
}
