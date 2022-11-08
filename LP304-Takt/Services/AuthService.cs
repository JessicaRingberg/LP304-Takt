using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<UserResponse<string>> ForgotPassword(string email)
        {
            return await _authRepository.ForgotPassword(email);
        }

        public async Task<UserResponse<string>> Login(string email, string password)
        {
            return await _authRepository.Login(email, password);
        }

        public async Task<UserResponse<string>> RefreshToken(string refreshToken)
        {
            return await _authRepository.RefreshToken(refreshToken);
        }

        public async Task<UserResponse<int>> RegisterUser(User user, string email, int companyId)
        {
            return await _authRepository.RegisterUser(user, email, companyId);
        }

        public async Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string passwordResetToken)
        {
            return await _authRepository.ResetPassword(request, passwordResetToken);
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await _authRepository.UserAlreadyExists(userName);
        }

        public async Task<UserResponse<string>> VerifyEmail(string verificationToken)
        {
            return await _authRepository.VerifyEmail(verificationToken);
        }
    }
}
