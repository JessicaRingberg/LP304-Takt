using System.Collections;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPost]
        public async Task<IActionResult> AddArea([FromBody] AreaCreateDto area, [FromQuery] int companyId)
        {
            var response = await _areaService.Add(area.AsEntity(), companyId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> GetAreas()
        {
            return Ok((await _areaService.GetEntities()).Select(c => c.AsDto()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaDto>> GetArea(int id)
        {
            var area = await _areaService.GetEntity(id);

            if (area is null)
            {
                return NotFound($"Area with id: {id} was not found");
            }

            return Ok(area.AsDto());
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var response = await _areaService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPut]
        public async Task<IActionResult> UpdateArea([FromBody] AreaUpdateDto area, [FromQuery] int areaId)
        {
            var response = await _areaService.UpdateEntity(area.AsUpdated(), areaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
