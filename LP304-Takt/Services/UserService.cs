﻿using LP304_Takt.Interfaces.Repositories;
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

        public async Task<ServiceResponse<int>> RegisterUser(User user, string email, int companyId)
        {
            return await _userRepository.RegisterUser(user, email, companyId);
        }

        public async Task<ServiceResponse<string>> LoginUser(string email, string password)
        {
            return await _userRepository.Login(email, password);
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

        public async Task<ServiceResponse<string>> ForgotPassword(string email)
        {
            return await _userRepository.ForgotPassword(email);
        }

        public async Task<ServiceResponse<string>> ResetPassword(ResetPasswordRequest request)
        {
            return await _userRepository.ResetPassword(request);
        }

        public async Task<ServiceResponse<string>> VerifyEmail(string token)
        {
            return await _userRepository.VerifyEmail(token);
        }

        public async Task<ServiceResponse<string>> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<ServiceResponse<string>> RefreshToken(string token)
        {
            return await _userRepository.RefreshToken(token);
        }
    }
}
