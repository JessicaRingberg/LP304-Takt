using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task Add(Company company);
        Task<ICollection<User>> GetUserByCompany(int companyId);
    }
}
