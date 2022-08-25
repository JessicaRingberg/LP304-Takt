using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _companyUoW;

        public CompanyService(IUnitOfWork companyUoW)
        {
            _companyUoW = companyUoW;
        }

        public Task<Company>  GetOneCompanyService(int id)
        {
            var company = _companyUoW.Companies.GetById(id);
            return company;
        }

        public Task<IEnumerable<Company>> GetAllCompaniesService()
        {
            var company = _companyUoW.Companies.GetAll();

            return company;
        }

    }
}
