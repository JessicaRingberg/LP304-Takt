using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = nameof(Role.Admin))]
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

        [HttpPost("forgot-password")]
        public async Task<ActionResult<ServiceResponse<string>>> ForgotPassword(string email)
        {
            var response = await _userService.ForgotPassword(email);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ServiceResponse<string>>> ResetPassword(ResetPasswordRequest request)
        {
            var response = await _userService.ResetPassword(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("verify")]
        public async Task<ActionResult<ServiceResponse<string>>> Verify(string token)
        {
            var response = await _userService.VerifyEmail(token);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ServiceResponse<string>>> RefreshToken(string token)
        {
            var response = await _userService.RefreshToken(token);
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
            return Ok((await _userService.GetAllUsers()).Select(user => user.AsDto()));
        }

        [Authorize]
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
        public async Task<ActionResult<ServiceResponse<string>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto user, [FromQuery] int userId)
        {
            var response = await _userService.UpdateUser(user.AsUpdated(), userId);

            return Ok();
        }
        //private void SetRefreshToken(string newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = DateTime.Now.AddDays(7)
        //    };
        //    Response.Cookies.Append("refreshToken", newRefreshToken, cookieOptions);

        //}
    }
}
