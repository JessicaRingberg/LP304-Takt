using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit.Text;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using LP304_Takt.Mapper;

namespace LP304_Takt.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
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
            { Success = true, Message = $"{user.VerificationToken}" };

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
                response.JWT = CreateJwtToken(verifiedUser);

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
                var newRefreshToken = GenerateRefreshToken();
                user.RefreshToken = newRefreshToken.Token;
                user.TokenCreated = newRefreshToken.Created;
                user.TokenExpires = newRefreshToken.Expires;


                var newJwt = CreateJwtToken(user);
                await _context.SaveChangesAsync();
                response.RefreshToken = newRefreshToken;
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
                user.VerificationToken = null;
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
            if (user is null || user.ResetTokenExpires < DateTime.Now)
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
            return new UserResponse<string> { Success = true, Message = "Password reset complete" };
        }

        public async Task<bool> UserAlreadyExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email.Equals(email)))
            {
                return true;
            }
            return false;
        }


        private string CreateJwtToken(User user)
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

        private static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
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

        private static void EmailToResetPassword(User user)
        {
            var url = "https://localhost:7112/api/User/Reset-Password?token=";
            var filePath = @"Templates/ResetPassword.html";
            StreamReader stream = new(filePath);
            string emailContent = stream.ReadToEnd();
            stream.Close();

            emailContent = emailContent.Replace("[user.FirstName]", user.FirstName);
            emailContent = emailContent.Replace("[resetTokenUrl]", url + user.PasswordResetToken);

            var message = new MimeMessage();
            message.To.Add(MailboxAddress.Parse("jerome.toy9@ethereal.email"));
            message.From.Add(MailboxAddress.Parse("jerome.toy9@ethereal.email"));
            message.Subject = "Password reset";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailContent
            };
            Smtp(message);
        }

        private static void EmailForVerification(User user)
        {
            var url = "https://localhost:7112/api/User/verify?token=";
            var filePath = @"Templates/VerifyEmail.html";
            StreamReader stream = new(filePath);
            string emailContent = stream.ReadToEnd();
            stream.Close();

            emailContent = emailContent.Replace("[user.FirstName]", user.FirstName);
            emailContent = emailContent.Replace("[verifyTokenUrl]", url + user.VerificationToken);

            var message = new MimeMessage();
            message.To.Add(MailboxAddress.Parse("jerome.toy9@ethereal.email"));
            message.From.Add(MailboxAddress.Parse("jerome.toy9@ethereal.email"));
            message.Subject = "Email verification";

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailContent
            };
            Smtp(message);
        }

        private static void Smtp(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("jerome.toy9@ethereal.email", "VYSqnWcNmUu8WznP4C");
            smtp.Send(email);

            smtp.Disconnect(true);
        }

    }
}
