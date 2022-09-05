using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserCreateDto user, [FromQuery] int companyId)
        {
            await _userService.Add(user.AsEntity(), companyId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok((await _userService.GetEntities()).Select(user => user.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetEntity(id);

            if (user == null)
            {
                return NotFound("User with id " + id + " was not found.");
            }

            return Ok(user.AsDto());
        }

        [HttpGet("{userId}/companies")]
        public async Task<ActionResult<CompanyDto>> GetUserByCompany(int userId)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteEntity(id);
            return Ok();
        }

    }
}
