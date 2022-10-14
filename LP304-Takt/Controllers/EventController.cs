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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //[Authorize(Roles = nameof(Role.Admin))]
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

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return Ok((await _eventService.GetEntities()).Select(e => e.AsDto()));
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var eEvent = await _eventService.GetEntity(id);

            if (eEvent is null)
            {
                return NotFound($"Event with id: {id} was not found");
            }

            return Ok(eEvent.AsDto());
        }

        //[Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var response = await _eventService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorize(Roles = nameof(Role.Admin))]
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
