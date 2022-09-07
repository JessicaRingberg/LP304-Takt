using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IConfigRepository : IBaseRepository<Config>
    {
        Task Add(Config config, int areaId);
    }
}
