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
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddArea([FromBody] AreaCreateDto area, [FromQuery] int companyId)
        {
            await _areaService.Add(area.AsEntity(), companyId);

            return Ok();
        }


    }
}
