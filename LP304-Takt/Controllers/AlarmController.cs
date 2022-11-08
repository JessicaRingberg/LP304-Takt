using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<IActionResult> AddAlarm([FromBody] AlarmCreateDto alarm, [FromQuery] int orderId, [FromQuery] int alarmTypeId)
        {
            var response = await _alarmService.Add(alarm.AsEntity(), orderId, alarmTypeId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<AlarmDto>>> GetAlarms()
        {
            return Ok((await _alarmService.GetEntities()).Select(a => a.AsDto()));
        }

        [HttpGet("{alarmId}")]
        public async Task<ActionResult<AlarmDto>> GetAlarm(int alarmId)
        {
            var alarm = await _alarmService.GetEntity(alarmId);

            if (alarm is null)
            {
                return NotFound($"Alarm with id: {alarmId} not found");
            }

            return Ok(alarm.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{alarmId}")]
        public async Task<IActionResult> DeleteAlarm(int alarmId)
        {
            var response = await _alarmService.DeleteEntity(alarmId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateAlarm([FromBody] AlarmUpdateDto alarm, [FromQuery] int alarmId)
        {
            var response = await _alarmService.UpdateEntity(alarm.AsUpdated(), alarmId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
