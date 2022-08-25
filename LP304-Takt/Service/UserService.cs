using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.UnitOfWork;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LP304_Takt.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _userUoW;

        public UserService(IUnitOfWork userUoW)
        {
            _userUoW = userUoW;
        }

        public async Task AddUser(User user)
        {
            await _userUoW.Users.Add(user);
            _userUoW.Complete();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
          var users = _userUoW.Users.GetAll();
          return await users;

        }

        public async Task<User> GetOneUser(int id)
        {
            var user = _userUoW.Users.GetById(id);
            return await user;
        }

        public async Task RemoveUser(User user)
        {
            await _userUoW.Users.Remove(user);
            _userUoW.Complete();
        }

        public async Task<User> UpdateUser(User user)
        {
            await _userUoW.Users.Update(user);
            _userUoW.Complete();
            return user;
        }
    }
}
