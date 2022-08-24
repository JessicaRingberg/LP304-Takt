using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(LP304Context context) : base(context)
        {
        }
    }
}
