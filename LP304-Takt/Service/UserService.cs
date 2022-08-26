using LP304_Takt.DTO;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.UnitOfWork;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LP304_Takt.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _userUnitOfWork;

        public UserService(IUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
          var users = _userUnitOfWork.Users.GetAll();
          return await users;

        }

        public async Task<User> GetOneUser(int id)
        {
            var user = _userUnitOfWork.Users.GetById(id);
            return await user;
        }

        public async Task AddUser(User user)
        {
            await _userUnitOfWork.Users.Add(user);
            _userUnitOfWork.Complete();
        }

        public async Task RemoveUser(User user)
        {
            await _userUnitOfWork.Users.Remove(user);
            _userUnitOfWork.Complete();
        }

        public async Task<User> UpdateUser(User user)
        {
            await _userUnitOfWork.Users.Update(user);
            _userUnitOfWork.Complete();
            return user;
        }

        public async Task DeleteById(int id)
        {
            await _userUnitOfWork.Users.DeleteAsync(id);
            _userUnitOfWork.Complete();
        }
    }
}
