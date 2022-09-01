using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _roleUnitOfWork;

        public RoleService(IUnitOfWork roleUnitOfWork)
        {
            _roleUnitOfWork = roleUnitOfWork;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = _roleUnitOfWork.Roles.GetAll();
            return await roles;
        }
        public async Task<Role> GetRole(int id)
        {
            var role = _roleUnitOfWork.Roles.GetById(id);
            return await role;
        }
        public async Task AddRole(Role role)
        {
            await _roleUnitOfWork.Roles.Add(role);
            _roleUnitOfWork.Complete();
        }

        public async Task RemoveRole(Role role)
        {
            await _roleUnitOfWork.Roles.Remove(role);
            _roleUnitOfWork.Complete();
        }
        public async Task DeleteById(int id)
        {
            var role = await _roleUnitOfWork.Roles.GetById(id);
            await _roleUnitOfWork.Roles.Remove(role);
            _roleUnitOfWork.Complete();

        }
        public async Task<Role> UpdateRole(Role role)
        {
            return await _roleUnitOfWork.Roles.Update(role);
        }
    }
}
