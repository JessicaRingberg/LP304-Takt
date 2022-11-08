using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventStatusController : ControllerBase
    {
        private readonly IEventStatusService _eventStatusService;

        public EventStatusController(IEventStatusService eventStatusService)
        {
            _eventStatusService = eventStatusService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
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

        [HttpGet("{eventStatusId}")]
        public async Task<ActionResult<EventStatusDto>> GetEventStatus(int eventStatusId)
        {
            var eventStatus = await _eventStatusService.GetEntity(eventStatusId);

            if (eventStatus is null)
            {
                return NotFound($"Event status with id: {eventStatusId} not found");
            }

            return Ok(eventStatus.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{eventStatusId}")]
        public async Task<IActionResult> DeleteEventStatus(int eventStatusId)
        {
            var response = await _eventStatusService.DeleteEntity(eventStatusId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
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
