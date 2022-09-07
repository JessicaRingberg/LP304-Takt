using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Add(Role role)
        {
            await _roleRepository.Add(role);
        }

        public async Task DeleteEntity(int id)
        {
            await _roleRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Role>> GetEntities()
        {
            return await _roleRepository.GetEntities();
        }

        public async Task<Role?> GetEntity(int id)
        {
            return await _roleRepository.GetEntity(id);
        }

        public Task UpdateEntity(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
