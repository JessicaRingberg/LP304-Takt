﻿using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> AddCompany(CompanyCreateDto company)
        {
            var response = await _companyService.Add(company.AsEntity());
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
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
            if (company is null)
            {
                return NotFound($"Company with id {id} was not found.");
            }

            return Ok(company.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpGet("{companyId}/users")]
        public async Task<ActionResult<List<UserDto>>> GetUserByCompany(int companyId)
        {
            var users = (await _companyService.GetUserByCompany(companyId)).Select(u => u.AsDto());
            return Ok(users);
        }

        //[Authorized(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var response = await _companyService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin)]
        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyUpdateDto company, [FromQuery] int companyId)
        {
            var response = await _companyService.UpdateEntity(company.AsUpdated(), companyId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
