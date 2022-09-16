using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<ServiceResponse<int>> Add(Company company);
        Task<ICollection<User>> GetUserByCompany(int companyId);

        

    }
}
