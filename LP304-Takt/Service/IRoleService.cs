using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IRoleService
    {
        Task<Role> GetRole(int id);
        Task<IEnumerable<Role>> GetAllRoles();
        Task AddRole(Role role);
        Task RemoveRole(Role role);
    }
}
