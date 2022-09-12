using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task Add(Role role);
        
    }
}
