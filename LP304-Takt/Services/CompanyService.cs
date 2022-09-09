using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;


namespace LP304_Takt.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task Add(Company company)
        {
            await _companyRepository.Add(company);
        }

        public async Task DeleteEntity(int id)
        {
            await _companyRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Company>> GetEntities()
        {
            return await _companyRepository.GetEntities();
        }

        public async Task<Company?> GetEntity(int id)
        {
            return await _companyRepository.GetEntity(id);
        }

        public async Task<ICollection<User>> GetUserByCompany(int companyId)
        {
            return await _companyRepository.GetUserByCompany(companyId);
        }

        public async Task UpdateEntity(Company company, int companyId)
        { 
            await _companyRepository.UpdateEntity(company, companyId);
        }


    }
}
