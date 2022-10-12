﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using MimeKit;
using MimeKit.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
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

        public async Task<UserResponse<int>> RegisterUser(User user, string password, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company is null)
            {
                return new UserResponse<int>()
                {
                    Success = false,
                    Message = "User must belong to a company"
                };
            }

            else if (await UserAlreadyExists(user.Email))
            {
                return new UserResponse<int>()
                {
                    Success = false,
                    Message = "Email already exists"
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.VerificationToken = CreateRandomToken();
          
            user.Role = Role.User;
            user.CompanyId = companyId;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            EmailForVerification(user);

            return new UserResponse<int> 
            {Success = true, Message = $"{user.VerificationToken}" };
            
        }

        public async Task<UserResponse<string>> Login(string email, string passWord)
        {
            var response = new UserResponse<string>();

            var verifiedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (verifiedUser is null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!VerifyPasswordHash(passWord, verifiedUser.PasswordHash, verifiedUser.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Password or email is incorrect";
            }
            else
            {            
                var refreshToken = GenerateRefreshToken();
                verifiedUser.RefreshToken = refreshToken.Token;
                verifiedUser.TokenCreated = refreshToken.Created;
                verifiedUser.TokenExpires = refreshToken.Expires;

                response.User = verifiedUser.AsDto();
                response.RefreshToken = refreshToken;
                response.Success = true;
                response.JWT = CreateToken(verifiedUser);
               
                await _context.SaveChangesAsync();

            }
           
            return response;
        }
      
        public async Task<UserResponse<string>> RefreshToken(string token)
        {
            var response = new UserResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == token);

            if (user is null)
            {
                response.Success = false;
                response.Message = "Not found";
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                response.Success = false;
                response.Message = "Token expired";
            }
            else
            {

                var newRefresToken = GenerateRefreshToken();
                user.RefreshToken = newRefresToken.Token;
                user.TokenCreated = newRefresToken.Created;
                user.TokenExpires = newRefresToken.Expires;


                var newJwt = CreateToken(user);
                await _context.SaveChangesAsync();
                response.RefreshToken = newRefresToken;
                response.User = user.AsDto();
                response.JWT = newJwt;
                response.Success = true;
                response.Message = $"New refresh token:{user.RefreshToken}";
                
            }
            return response;
        }

        public async Task<UserResponse<string>> VerifyEmail(string token)
        {
            var response = new UserResponse<string>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user is null)
            {
                response.Success = false;
                response.Message = "Invalid token";
            }
            else
            {
                user.VerifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "Email verified";
            }
            
            return response;
        }

        public async Task<UserResponse<string>> ForgotPassword(string email)
        {
            var response = new UserResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";                
            }
            else if (user.VerifiedAt is null)
            {
                response.Success = false;
                response.Message = "User not verified";
            }
            else
            {
                user.PasswordResetToken = CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);
                await _context.SaveChangesAsync();
                EmailToResetPassword(user);

                response.Message = $"Email to reset password has been sent to {user.Email}";
                response.Success = true;
                

            }
   
            return response; 

        }

        public async Task<UserResponse<string>> ResetPassword(ResetPasswordRequest request, string token)
        {
            var response = new UserResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
            if(user is null || user.ResetTokenExpires < DateTime.Now)
            {
                response.Success = false;
                response.Message = "Invalid token";
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user!.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();
            return new UserResponse<string> { Success = true, Message = "Password reset complete" };
        }


        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users
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

   

        public async Task<UserResponse<int>> UpdateUser(User user, int userId)
        {

            var userToUpdate = await _context.Users
                .FindAsync(userId);
            if (userToUpdate is null)
            {
                return new UserResponse<int>()
                {
                    Success = false,
                    Message = $"User with id: {userId} was not found"
                };
            }

            MapUser(userToUpdate, user);

            await _context.SaveChangesAsync();
            return new UserResponse<int>()
            {
                Success = true,
                Message = $"User with id: {userId} updated"
            };
        }

        private static User MapUser(User newUser, User oldUser)
        {

            newUser.FirstName = oldUser.FirstName;
            newUser.LastName = oldUser.LastName;
            newUser.Email = oldUser.Email;
            return newUser;
        }

       




        private string CreateToken(User user)
        {

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
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

        public async Task<bool> UserAlreadyExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email.Equals(email)))
            {
                return true;
            }
            return false;
        }

        private static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private static void EmailToResetPassword(User user)
        {
            var message = new MimeMessage();
            message.To.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));//user.Email
            message.From.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
            message.Subject = "Password reset";
            //Something like this:
            var url = "https://localhost:7112/api/User/Reset-Password?token=";
            message.Body = new TextPart(TextFormat.Html)
            { Text = $"<a href=\"{url}{user.PasswordResetToken}\">Reset password</a>" };
            Smtp(message);
        }

        private static void EmailForVerification(User user)
        {
            var message = new MimeMessage();
            message.To.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));//user.Email
            message.From.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
            message.Subject = "Email verification";
            var url = "https://localhost:7112/api/User/verify?token=";
            message.Body = new TextPart(TextFormat.Html)
            { Text = $"<a href=\"{url}{user.VerificationToken}\">Verify email</a>" };
            Smtp(message);
        }
        private static void Smtp(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("dayne.renner@ethereal.email", "EGQ6HC9nprSc1g77h9");
            smtp.Send(email);

            smtp.Disconnect(true);
        }


        private static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }

        
    }
}
