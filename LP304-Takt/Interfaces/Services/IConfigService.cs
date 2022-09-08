using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IConfigService : IBaseService<Config>
    {
        Task Add(Config config, int areaId);
        Task UpdateConfig(Config config, int configId);
    }
}
