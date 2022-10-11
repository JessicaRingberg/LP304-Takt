using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmTypeController : ControllerBase
    {
        private readonly IAlarmTypeService _alarmTypeService;

        public AlarmTypeController(IAlarmTypeService alarmTypeService)
        {
            _alarmTypeService = alarmTypeService;
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> AddAlarmType(AlarmTypeCreateDto alarmType)
        {
            var response = await _alarmTypeService.Add(alarmType.AsEntity());
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<List<AlarmTypeDto>>> GetAlarmTypes()
        {
            return Ok((await _alarmTypeService.GetEntities()).Select(a => a.AsDto()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AlarmTypeDto>> GetAlarmType(int id)
        {
            var alarmType = await _alarmTypeService.GetEntity(id);

            if (alarmType is null)
            {
                return NotFound($"Alarm type with id {id} was not found.");
            }

            return Ok(alarmType.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlarmType(int id)
        {
            var response = await _alarmTypeService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlarmType([FromBody] AlarmTypeUpdateDto alarmType, [FromQuery] int alarmTypeId)
        {
            var response = await _alarmTypeService.UpdateEntity(alarmType.AsUpdated(), alarmTypeId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
