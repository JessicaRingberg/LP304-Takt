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

        //[HttpGet("{id}")]
        //public User GetOneUser(int id)
        //{
        //    return _userService.GetOneUserService(id);
        //}

    }
}
