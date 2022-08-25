using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.UnitOfWork;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LP304_Takt.Service
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork.UnitOfWork _userUoW;

        public UserService(UnitOfWork.UnitOfWork userUoW)
        {
            _userUoW = userUoW;
        }
       

        //public User GetOneUserService(int id)
        //{
        //    var user = _userUoW.Users.GetById(id);
        //    return user;
        //}
    }
}
