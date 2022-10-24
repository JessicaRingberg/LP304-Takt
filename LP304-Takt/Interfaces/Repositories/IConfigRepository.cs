using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IConfigRepository : IBaseRepository<Config>
    {
        Task<ServiceResponse<int>> Add(Config config, int areaId);
        
    }
}
