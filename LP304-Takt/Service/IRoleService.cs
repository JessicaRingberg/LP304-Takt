using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRole(int id);
        Task AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task RemoveRole(Role role);
        Task DeleteById(int id);
    }
}
