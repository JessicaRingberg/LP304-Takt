
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LP304_Takt.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user, int companyId)
        {
            await _userRepository.Add(user, companyId);
        }

        public async Task<ICollection<User>> GetEntities()
        {
            return await _userRepository.GetEntities();
        }

        public async Task<User> GetEntity(int id)
        {
            return await _userRepository.GetEntity(id);
        }

        public async Task<Company> GetCompanyByUser(int userId)
        {
            return await _userRepository.GetCompanyByUser(userId);
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
