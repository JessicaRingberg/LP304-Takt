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
        public async Task<IActionResult> AddEvent([FromBody] EventCreateDto eEvent, [FromQuery] int orderId)
        { 
            await _eventService.Add(eEvent.AsEntity(), orderId);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return Ok((await _eventService.GetEntities()).Select(e => e.AsDto()));
        }
    }
}
