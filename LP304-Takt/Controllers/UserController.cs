using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Service;
using LP304_Takt.UnitOfWork;
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

        [HttpGet("{id}")]
        public async Task<User> GetOneUser(int id)
        {
            return await _userService.GetOneUser(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await _userService.AddUser(user);
        }

        [HttpDelete]
        public async Task RemoveUser(User user)
        {
            await _userService.RemoveUser(user);
        }

        [HttpPut]
        public async Task UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
        }

    }
}
