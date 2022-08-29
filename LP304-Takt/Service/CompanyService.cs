using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _companyUnitOfWork;

        public CompanyService(IUnitOfWork companyUnitOfWork)
        {
            _companyUnitOfWork = companyUnitOfWork;
        }
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            var company = _companyUnitOfWork.Companies.GetAll();

            return await company;
        }

        public async Task<Company>  GetOneCompany(int id)
        {
            var company = _companyUnitOfWork.Companies.GetById(id);
            return await company;
        }


        public async Task AddCompany(Company company)
        {
            await _companyUnitOfWork.Companies.Add(company);
            _companyUnitOfWork.Complete();

        }

        public async Task RemoveCompany(Company company)
        { 
            await _companyUnitOfWork.Companies.Remove(company);
            _companyUnitOfWork.Complete();
        }
        public async Task DeleteById(int id)
        {
            var company = await _companyUnitOfWork.Companies.GetById(id);
            await _companyUnitOfWork.Companies.Remove(company);
            _companyUnitOfWork.Complete();

        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return await _companyUnitOfWork.Companies.Update(company);
        }
    }
}
