using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
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
        {//If company is null return 
            await _areaService.Add(area.AsEntity(), companyId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> GetAreas()
        {
            return Ok((await _areaService.GetEntities()).Select(c => c.AsDto()));
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _areaService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArea([FromBody] AreaUpdateDto area, [FromQuery] int areaId)
        {
            await _areaService.UpdateEntity(area.AsUpdated(), areaId);

            return Ok();
        }
    }
}
