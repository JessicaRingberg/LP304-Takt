using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public interface ICompanyService
    {
        Task<Company> GetOneCompanyService(int id);
        Task<IEnumerable<Company>> GetAllCompaniesService();
    }
}
