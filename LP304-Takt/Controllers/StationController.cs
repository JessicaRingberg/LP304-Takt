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
    }
}
