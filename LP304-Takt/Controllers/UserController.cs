using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.ReadDTO;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }      

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok((await _userService.GetAllUsers()).Select(user => user.AsDto()));
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            
            if (user is null)
            {
                return NotFound($"User with id {id} was not found.");
            }

            return Ok(user.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpGet("companies/{userId}")]
        public async Task<ActionResult<CompanyByUserDto>> GetCompanyByUser(int userId)
        {
            var company = await _userService.GetCompanyByUser(userId);
            if (company is null)
            {
                return NotFound("Not found");
            }
            return Ok(company.AsUserCompanyDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto user, [FromQuery] int userId)
        {
            var response = await _userService.UpdateUser(user.AsUpdated(), userId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut("{userId}/assignArea")]
        public async Task<IActionResult> AddAreaToUser(int userId, int areaId)
        {
            var response = await _userService.AddAreaToUser(userId, areaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPatch]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleDto user, [FromQuery] int userId)
        {
            var response = await _userService.UpdateUserRole(user.UpdatedRole(), userId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

      
    }
}
