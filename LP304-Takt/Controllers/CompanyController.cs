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
        //private readonly CompanyService _companyService;
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{id}")]
        public async Task<Company> GetOneCompanyS(int id)
        {
            return await _companyService.GetOneCompanyService(id);
        }

        [HttpGet]
        public async Task <IEnumerable> GetAll()
        {
            return await _companyService.GetAllCompaniesService();
        }
    }
}
