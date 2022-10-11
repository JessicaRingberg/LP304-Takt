using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ServiceResponse<int>> Add(Company company)
        {
            return await _companyRepository.Add(company);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            return await _companyRepository.DeleteEntity(id);
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

        public async Task<ServiceResponse<int>> UpdateEntity(Company company, int companyId)
        { 
            return await _companyRepository.UpdateEntity(company, companyId);
        }


    }
}
