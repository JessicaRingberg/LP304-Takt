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

        public async Task<UserResponse<int>> RegisterUser(User user, string email, int companyId)
        {
            return await _userRepository.RegisterUser(user, email, companyId);
        }

        public async Task<UserResponse<string>> LoginUser(string email, string password)
        {
            return await _userRepository.Login(email, password);
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> GetCompanyByUser(int userId)
        {
            return await _userRepository.GetCompanyByUser(userId);
        }

        public async Task<UserResponse<string>> ForgotPassword(string email)
        {
            return await _userRepository.ForgotPassword(email);
        }

        public async Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string token)
        {
            return await _userRepository.ResetPassword(request, token);
        }

        public async Task<UserResponse<string>> VerifyEmail(string token)
        {
            return await _userRepository.VerifyEmail(token);
        }

        public async Task<UserResponse<string>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<UserResponse<string>> RefreshToken(string token)
        {
            return await _userRepository.RefreshToken(token);
        }

        public async Task<UserResponse<int>> UpdateUser(User user, int id)
        {
            return await _userRepository.UpdateUser(user, id);
        }

        public async Task<UserResponse<int>> UpdateUserRole(User user, int id)
        {
            return await _userRepository.UpdateUserRole(user, id);
        }
    }
}
