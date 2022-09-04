using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company?> GetCompanyWithAreas(int id);
        Task<IEnumerable<Company>> GetCompaniesWithAreas();
        Task RemoveCompanyById(int id);
    }
}
