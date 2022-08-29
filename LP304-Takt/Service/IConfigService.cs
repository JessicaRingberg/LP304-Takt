using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IConfigService
    {
        Task<IEnumerable<Config>> GetAllConfig();
        Task<Config> GetOneConfig(int id);
        Task AddConfig(Config config);
        Task<Config> UpdateConfig(Config config);
        Task RemoveConfig(Config config);
        Task DeleteById(int id);
    }
}
