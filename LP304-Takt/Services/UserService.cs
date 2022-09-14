using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
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

        public async Task<User?> GetEntity(int id)
        {
            return await _userRepository.GetEntity(id);
        }

        public async Task<Company?> GetCompanyByUser(int userId)
        {
            return await _userRepository.GetCompanyByUser(userId);
        }

        public async Task DeleteEntity(int id)
        {
            await _userRepository.DeleteEntity(id);
        }

        public async Task UpdateEntity(User user, int userId)
        {
           await _userRepository.UpdateEntity(user, userId);
        }
        
        public async Task<ServiceResponse<int>> RegisterUser(User user, string email)
        {
            return await _userRepository.RegisterUser(user, email);
        }

        public async Task<ServiceResponse<string>> LoginUser(string userName, string password)
        {
            return await _userRepository.Login(userName, password);
        }

    }
}
