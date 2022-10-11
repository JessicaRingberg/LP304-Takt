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
    public class EventStatusController : ControllerBase
    {
        private readonly IEventStatusService _eventStatusService;

        public EventStatusController(IEventStatusService eventStatusService)
        {
            _eventStatusService = eventStatusService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEventStatus([FromBody] EventStatusCreateDto eventStatus)
        {
            var response = await _eventStatusService.Add(eventStatus.AsEntity());
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<EventStatusDto>>> GetEventStatuses()
        {
            return Ok((await _eventStatusService.GetEntities()).Select(e => e.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventStatusDto>> GetEventStatus(int id)
        {
            var eventStatus = await _eventStatusService.GetEntity(id);

            if (eventStatus is null)
            {
                return NotFound($"Event status with id: {id} not found");
            }

            return Ok(eventStatus.AsDto());
        }

        [HttpDelete("{id}"), Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteEventStatus(int id)
        {
            var response = await _eventStatusService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut, Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateEventStatus([FromBody] EventStatusUpdateDto eventStatus, [FromQuery] int eventStatusId)
        {
            var response = await _eventStatusService.UpdateEntity(eventStatus.AsUpdated(), eventStatusId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
