﻿using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
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

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpGet("{areaId}/events")]
        public async Task<ActionResult<Event>> GetEventsByArea(int areaId)
        {
            var events = (await _areaService.GetEventsByArea(areaId)).Select(e => e.AsDto());

            if (events is null)
            {
                return NotFound($"Area with id: {areaId} was not found");
            }

            return Ok(events);
        }
        [HttpGet("{areaId}/alarms")]
        public async Task<ActionResult<Alarm>> GetAlarmsByArea(int areaId)
        {
            var alarm = (await _areaService.GetAlarmsByArea(areaId)).Select(e => e.AsDto());

            if (alarm is null)
            {
                return NotFound($"Area with id: {areaId} was not found");
            }

            return Ok(alarm);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
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

        //[Authorized(Role.Admin, Role.SuperUser)]
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
