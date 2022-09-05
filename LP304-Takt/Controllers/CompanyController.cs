using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
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

        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> GetCompanies()
        {
            return Ok((await _companyService.GetEntities()).Select(c => c.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company = await _companyService.GetEntity(id);

            if (company == null)
            {
                return NotFound("User with id " + id + " was not found.");
            }

            return Ok(company.AsDto());
        }

        [HttpGet("{companyId}/users")]
        public async Task<ActionResult<List<UserDto>>> GetUserByCompany(int companyId)
        {
            var users = (await _companyService.GetUserByCompany(companyId)).Select(u => u.AsDto());
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyCreateDto company)
        {
            await _companyService.Add(company.AsEntity());

            return Ok();
        }

    }
}
