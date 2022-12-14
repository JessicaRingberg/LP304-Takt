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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventCreateDto eEvent, [FromQuery] int orderId, [FromQuery] int eventStatusId)
        { 
            var response = await _eventService.Add(eEvent.AsEntity(), orderId, eventStatusId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return Ok((await _eventService.GetEntities()).Select(e => e.AsDto()));
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> GetEvent(int eventId)
        {
            var eEvent = await _eventService.GetEntity(eventId);

            if (eEvent is null)
            {
                return NotFound($"Event with id: {eventId} was not found");
            }

            return Ok(eEvent.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var response = await _eventService.DeleteEntity(eventId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromBody] EventUpdateDto eEvent, [FromQuery] int eventId)
        {
            var response = await _eventService.UpdateEntity(eEvent.AsUpdated(), eventId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
