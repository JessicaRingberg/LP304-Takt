using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetOneCompany(int id);
        Task AddCompany(Company company);
        Task RemoveCompany(Company company);
        Task DeleteById(int id);
    }
}
