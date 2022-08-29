using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<Role> GetRole(int id)
        {
            return await _roleService.GetRole(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _roleService.GetAllRoles();
        }

        [HttpPost]
        public async Task AddRole(Role role)
        {
            await _roleService.AddRole(role);
        }

        [HttpDelete]
        public async Task RemoveRole(Role role)
        {
            await _roleService.RemoveRole(role);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRoleById(int id)
        {
            await _roleService.DeleteById(id);


        }
    }
}
