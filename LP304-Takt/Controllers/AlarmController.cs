﻿using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAlarm([FromBody] AlarmCreateDto alarm, [FromQuery] int orderId, [FromQuery] int alarmTypeId)
        {
            await _alarmService.Add(alarm.AsEntity(), orderId, alarmTypeId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<AlarmDto>>> GetAlarms()
        {
            return Ok((await _alarmService.GetEntities()).Select(a => a.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlarmDto>> GetAlarm(int id)
        {
            var alarm = await _alarmService.GetEntity(id);

            if (alarm is null)
            {
                return NotFound($"Alarm with id: {id} not found");
            }

            return Ok(alarm.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _alarmService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlarm([FromBody] AlarmUpdateDto alarm, [FromQuery] int alarmId)
        {
            await _alarmService.UpdateAlarm(alarm.AsUpdated(), alarmId);

            return Ok();
        }
    }
}
