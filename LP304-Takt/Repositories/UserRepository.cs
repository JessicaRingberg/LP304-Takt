using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task Add(User user, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            //var role = await _context.Roles.FindAsync(1);
            //if (role is null)
            //{
            //    role = new Role() { Name = "DefaultRole", Users = new List<User>() };
            //    role.Users.Add(user);
            //}

            if (company != null)
            {
               // user.Role = role;
                user.CompanyId = companyId;
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetEntity(int id)
        {
            return await _context.Users
                //.Include(user => user.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<User>> GetEntities()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<Company?> GetCompanyByUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return user.Company;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async Task DeleteEntity(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                return;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(User user, int userId)
        {

            var userToUpdate = await _context.Users
                .FindAsync(userId);
            if (userToUpdate is null)
            {
                return;
            }

            MapUser(userToUpdate, user);

            await _context.SaveChangesAsync();
        }

        private static User MapUser(User newUser, User oldUser)
        {
            newUser.UserName = oldUser.UserName;
            newUser.Email = oldUser.Email;
            //newUser.Password = oldUser.Password;
            return newUser;
        }

        public async Task<ServiceResponse<int>> RegisterUser(User user, string password)
        {
            if(await UserAlreadyExists(user.UserName))
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "Username already exists"
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
          
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = Role.Admin;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful" };
        }

        public async Task<ServiceResponse<string>> Login(string userName, string passWord)
        {
            var response = new ServiceResponse<string>();

            var verifiedUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
            if(verifiedUser is null)
            {
                response.Success = false;
                response.Message = "Username not found";

            }
            else if(!VerifyPasswordHash(passWord, verifiedUser.PasswordHash, verifiedUser.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password";
            }
            else
            {
                response.Success = true;
                response.Data = CreateToken(verifiedUser);
            }

            return response;
        }

        private string CreateToken(User user)
        {

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public async Task<bool> UserAlreadyExists(string username)
        {
            if (await _context.Users.AnyAsync(user => user.UserName.Equals(username)))
            {
                return true;
            }
            return false;
        }
    }
}
