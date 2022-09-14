using LP304_Takt.Models;
using LP304_Takt.Shared;
using NuGet.Protocol.Plugins;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task Add(User user, int companyId);
        Task<Company?> GetCompanyByUser(int userId);
        Task<bool> UserAlreadyExists(string userName);
        Task<ServiceResponse<int>> RegisterUser(User user, string email);
        Task<ServiceResponse<string>> Login(string userName, string passWord);




    }
}
