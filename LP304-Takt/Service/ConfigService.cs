using System.Runtime.CompilerServices;
using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class ConfigService : IConfigService
    {
        private readonly IUnitOfWork _configUnitOfWork;

        public ConfigService(IUnitOfWork configUnitOfWork)
        {
            _configUnitOfWork = configUnitOfWork;
        }
        public async Task AddConfig(Config config)
        {
            await _configUnitOfWork.Configs.Add(config);
        }

        public async Task<IEnumerable<Config>> GetAllConfig()
        {
           return await _configUnitOfWork.Configs.GetAll();
        }

        public async Task<Config> GetOneConfig(int id)
        {
            return await _configUnitOfWork.Configs.GetById(id);
        }

        public async Task RemoveConfig(Config config)
        {
            await _configUnitOfWork.Configs.Remove(config);
        }
        public async Task DeleteById(int id)
        {
            var config = await _configUnitOfWork.Configs.GetById(id);
            await _configUnitOfWork.Configs.Remove(config);
            _configUnitOfWork.Complete();

        }

        public async Task<Config> UpdateConfig(Config config)
        {
            return await _configUnitOfWork.Configs.Update(config);
        }
    }
}
