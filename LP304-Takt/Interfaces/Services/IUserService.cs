
using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task Add(User user, int companyId);
        Task<Company?> GetCompanyByUser(int userId);
    }
}
