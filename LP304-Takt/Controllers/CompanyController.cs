using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<Company> GetOneCompany(int id)
        {
            return await _companyService.GetOneCompany(id);
        }

        [HttpGet]
        public async Task <IEnumerable> GetAll()
        {
            return await _companyService.GetAllCompanies();
        }

        [HttpPost]
        public async Task AddCompany(Company company)
        {
            await _companyService.AddCompany(company);
        }

        [HttpDelete]
        public async Task RemoveCompany(Company company)
        { 
            await _companyService.RemoveCompany(company);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCompanyById(int id)
        {
            await _companyService.DeleteById(id);


        }
    }
}
