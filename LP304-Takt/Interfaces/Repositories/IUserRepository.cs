using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task Add(User user, int companyId);
        Task<Company?> GetCompanyByUser(int userId);
    }
}
