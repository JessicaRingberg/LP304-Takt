using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister user, [FromQuery] int companyId)
        {
            var response = await _userService.RegisterUser(new User
            { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email }, user.Password, companyId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _userService.LoginUser(request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [Authorize(Roles = nameof(Role.Admin))]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok((await _userService.GetEntities()).Select(user => user.AsDto()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetEntity(id);

            if (user is null)
            {
                return NotFound($"User with id {id} was not found.");
            }

            return Ok(user.AsDto());
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpGet("{userId}/companies")]
        public async Task<ActionResult<CompanyDto>> GetUserByCompany(int userId)
        {
            var company = await _userService.GetCompanyByUser(userId);
            if (company is null)
            {
                return NotFound("Not found");
            }
            return Ok(company.AsDto());
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteEntity(id);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto user, [FromQuery] int userId)
        {
            await _userService.UpdateEntity(user.AsUpdated(), userId);

            return Ok();
        }


    }
}
