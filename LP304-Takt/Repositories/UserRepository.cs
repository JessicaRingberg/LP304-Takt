﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System.ComponentModel.Design;
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

        public async Task<ServiceResponse<int>> RegisterUser(User user, string password, int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "User must belong to a company"
                };
            }

            else if (await UserAlreadyExists(user.Email))
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
            user.VerificationToken = CreateRandomToken();
            user.Role = Role.User;
            user.CompanyId = companyId;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            //Mail containing verificationToken sent 
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
            message.To.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
            message.Subject = "Registration verification";
            message.Body = new TextPart(TextFormat.Html) { Text = user.VerificationToken };
            // Console.WriteLine($"{message}");

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("dayne.renner@ethereal.email", "EGQ6HC9nprSc1g77h9");
            smtp.Send(message);
            smtp.Disconnect(true);

            return new ServiceResponse<int> 
            { Data = user.Id, Success = true, Message = $"{user.VerificationToken}" };
            
        }
      

        public async Task<ServiceResponse<string>> Login(string email, string passWord)
        {
            var response = new ServiceResponse<string>();

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
            //else if (verifiedUser.VerifiedAt is null)
            //{
            //    response.Success = false;
            //    response.Message = $"{email} is not a verified email";
            //}
            else
            {
                response.Success = true;
                response.Data = CreateToken(verifiedUser);
                response.Message = $"Logged in: {verifiedUser.FirstName}";
            }

            return response;
        }

        public async Task<ServiceResponse<string>> VerifyEmail(string token)
        {
            var response = new ServiceResponse<string>();

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

        public async Task<ServiceResponse<string>> ForgotPassword(string email)
        {
            var response = new ServiceResponse<string>();
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
                //Ok -mail containing resetToken sent to user, redirection to endpoint: reset-password.
                user.PasswordResetToken = CreateRandomToken();
                user.ResetTokenExpires = DateTime.Now.AddDays(1);
                response.Data = user.PasswordResetToken;
                response.Message = $"Email to reset password haes ben sent to {user.Email}";
                response.Success = true;
                await _context.SaveChangesAsync();

                var message = new MimeMessage();
                message.To.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
                message.From.Add(MailboxAddress.Parse("dayne.renner@ethereal.email"));
                message.Subject = "Password reset";
                message.Body = new TextPart(TextFormat.Html) { Text = user.PasswordResetToken };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("dayne.renner@ethereal.email", "EGQ6HC9nprSc1g77h9");
                smtp.Send(message);
                smtp.Disconnect(true);
            }
   
            return response; 

        }

        public async Task<ServiceResponse<string>> ResetPassword(ResetPasswordRequest request)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if(user is null || user.ResetTokenExpires < DateTime.Now)
            {
                response.Success = false;
                response.Message = "Invalid token";
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();
            return new ServiceResponse<string> { Success = true, Message = "Password reset complete" };
        }


        public async Task<User?> GetEntity(int id)
        {
            return await _context.Users
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
            return user?.Company;
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

        public async Task<bool> UserAlreadyExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email.Equals(email)))
            {
                return true;
            }
            return false;
        }


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

    }
}
