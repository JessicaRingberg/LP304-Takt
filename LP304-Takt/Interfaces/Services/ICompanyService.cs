using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        Task<ICollection<User>> GetUserByCompany(int companyId);
        Task Add(Company company);
        Task Update(Company company);
    }
}
