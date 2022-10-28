using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<IActionResult> AddStation([FromBody] StationCreateDto station, [FromQuery] int areaId)
        {
            var response = await _stationService.Add(station.AsEntity(), areaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<StationDto>>> GetStations()
        {
            return Ok((await _stationService.GetEntities()).Select(s => s.AsDto()));
        }

        //[Authorized(Role.SuperUser)]
        [HttpGet("{id}")]
        public async Task<ActionResult<StationDto>> GetOneStation(int id)
        {
            var station = await _stationService.GetEntity(id);

            if (station is null)
            {
                return NotFound($"Station with id {id} was not found.");
            }

            return Ok(station.AsDto());
        }

        //[Authorized(Role.SuperUser, Role.User)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            var response = await _stationService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateStation([FromBody] StationUpdateDto station, [FromQuery] int stationId)
        {
            var response = await _stationService.UpdateEntity(station.AsUpdated(), stationId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
