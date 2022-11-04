using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IConfigService : IBaseService<Config>
    {
        Task<ServiceResponse<Config>> Add(Config config, int areaId);       
    }
}
