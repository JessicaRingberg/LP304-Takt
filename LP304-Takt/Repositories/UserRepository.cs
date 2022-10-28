using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LP304_Takt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        


        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.Area) 
                .ToListAsync();
        }

        public async Task<User?> GetCompanyByUser(int id)
        {
            var user = await _context.Users
                .Include(u=> u.Company)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<UserResponse<string>> DeleteUser(int id)
        {
            var response = new UserResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                response.Success = false;
                response.Message = "No user found";
            }
            else if(user.Role.Equals(Role.Admin))
            {
                response.Success = false;
                response.Message = "Admin cannot be removed";
            }
            else
            {
                response.Success = true;
                response.Message = $"User with email{user.Email} successfully removed.";
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
           
            return response;
        }


        public async Task<UserResponse<int>> UpdateUserRole(User user, int userId)
        {

            var userToUpdate = await _context.Users
                .FindAsync(userId);
            if (userToUpdate is null)
            {
                return new UserResponse<int>()
                {
                    Success = false,
                    Message = $"User with id {userId} was not found"
                };
            }

            userToUpdate.Role = user.Role;

            await _context.SaveChangesAsync();
            return new UserResponse<int>()
            {
                Success = true,
                Message = $"User with id {userId} updated"
            };
        }

        public async Task<UserResponse<int>> UpdateUser(User user, int userId)
        {

            var userToUpdate = await _context.Users
                .FindAsync(userId);
            if (userToUpdate is null)
            {
                return new UserResponse<int>()
                {
                    Success = false,
                    Message = $"User with id {userId} was not found"
                };
            }
            

            MapUser(userToUpdate, user);

            await _context.SaveChangesAsync();
            return new UserResponse<int>()
            {
                Success = true,
                Message = $"User with id {userId} updated",
                User = userToUpdate.AsDto()
            };
        }

        private static User MapUser(User newUser, User oldUser)
        {
            newUser.FirstName = oldUser.FirstName;
            newUser.LastName = oldUser.LastName;
            newUser.Email = oldUser.Email;
            return newUser;
        }   



        
        public async Task<UserResponse<string>> AddAreaToUser(int userId, int areaId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var area = await _context.Areas.FirstOrDefaultAsync(a => a.Id == areaId);
            if (user is null)
            {
                return new UserResponse<string>()
                {
                    Success = false,
                    Message = $"User was not found"
                };
            }          
            else if (area is null)
            {
                return new UserResponse<string>()
                {
                    Success = false,
                    Message = $"Area was not found"
                };
            }
            else if(user.CompanyId != area.CompanyId)
            {
                return new UserResponse<string>()
                {
                    Success = false,
                    Message = $"Area must belong to same company as user does!"
                };
            }
            else
            user.Area = area;
            await _context.SaveChangesAsync();
            return new UserResponse<string>()
            {
                Success = true,
                Message = $"User with id {userId} updated",
                User = user.AsDto()
            };
        }
    }
}
