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

        public Task<Company>  GetOneCompany(int id)
        {
            var company = _companyUoW.Companies.GetById(id);
            return company;
        }

        public Task<IEnumerable<Company>> GetAllCompanies()
        {
            var company = _companyUoW.Companies.GetAll();

            return company;
        }

        public async Task AddCompany(Company company)
        {
            await _companyUoW.Companies.Add(company);
            _companyUoW.Complete();

        }

        public async Task RemoveCompany(Company company)
        { 
            await _companyUoW.Companies.Remove(company);
            _companyUoW.Complete();
        }
    }
}
