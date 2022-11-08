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
        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<User?> GetCompanyByUser(int userId)
        {
            return await _userRepository.GetCompanyByUser(userId);
        }

        public async Task<UserResponse<string>> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }

        public async Task<UserResponse<int>> UpdateUser(User user, int userId)
        {
            return await _userRepository.UpdateUser(user, userId);
        }

        public async Task<UserResponse<int>> UpdateUserRole(User user, int userId)
        {
            return await _userRepository.UpdateUserRole(user, userId);
        }

        public async Task<UserResponse<string>> AddAreaToUser(int userId, int areaId)
        {
            return await _userRepository.AddAreaToUser(userId, areaId);
        }
    }
}
