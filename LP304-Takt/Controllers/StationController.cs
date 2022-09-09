﻿using System.Collections;
using LP304_Takt.DTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStation([FromBody] StationCreateDto station, [FromQuery] int areaId)
        {
            await _stationService.Add(station.AsEntity(), areaId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<StationDto>>> GetStations()
        {
            return Ok((await _stationService.GetEntities()).Select(s => s.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StationDto>> GetCompany(int id)
        {
            var station = await _stationService.GetEntity(id);

            if (station is null)
            {
                return NotFound($"Station with id {id} was not found.");
            }

            return Ok(station.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            await _stationService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStation([FromBody] StationUpdateDto station, [FromQuery] int stationId)
        {
            await _stationService.UpdateEntity(station.AsUpdated(), stationId);

            return Ok();
        }
    }
}
