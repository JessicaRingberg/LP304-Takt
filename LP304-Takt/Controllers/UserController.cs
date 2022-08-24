using LP304_Takt.Models;
using LP304_Takt.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] int count)
        {
            var users = _unitOfWork.Users.GetUsers(count);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            _unitOfWork.Users.Add(new User());
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
