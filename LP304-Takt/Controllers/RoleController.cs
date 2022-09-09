using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Services;
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

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleCreateDto role)
        {
            await _roleService.Add(role.AsEntity());

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetRoles()
        {
            return Ok((await _roleService.GetEntities()).Select(c => c.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _roleService.GetEntity(id);

            if (role is null)
            {
                return NotFound($"Role with id: {id} was not found");
            }

            return Ok(role.AsDto());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] RoleUpdateDto role, [FromQuery] int roleId)
        {
            await _roleService.UpdateRole(role.AsUpdated(), roleId);

            return Ok();
        }
    }
}
