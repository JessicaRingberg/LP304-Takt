using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public interface ICompanyService
    {
        Task<Company> GetOneCompany(int id);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task AddCompany(Company company);
        Task RemoveCompany(Company company);
    }
}
