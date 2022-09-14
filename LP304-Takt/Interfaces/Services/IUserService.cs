
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task Add(User user, int companyId);
        Task<Company?> GetCompanyByUser(int userId);
        Task<ServiceResponse<int>> RegisterUser(User user, string password, int companyId);
        Task<ServiceResponse<string>> LoginUser(string userName, string password);



    }
}
