using LP304_Takt.DTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
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
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventCreateDto eEvent, [FromQuery] int orderId, [FromQuery] int eventStatusId)
        { 
            await _eventService.Add(eEvent.AsEntity(), orderId, eventStatusId);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return Ok((await _eventService.GetEntities()).Select(e => e.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var eEvent = await _eventService.GetEntity(id);

            if (eEvent is null)
            {
                return NotFound($"Event with id: {id} not found");
            }

            return Ok(eEvent.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEntity(id);
            return Ok();
        }
    }
}
