using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
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

        [HttpGet("{id}")]
        public async Task<Event> GetOneEvent(int id)
        {
            return await _eventService.GetOneEvent(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _eventService.GetAllEvents();
        }

        [HttpPost]
        public async Task AddEvent(Event eEvent)
        {
            await _eventService.AddEvent(eEvent);
        }

        [HttpDelete]
        public async Task RemoveEvent(Event eEvent)
        {
            await _eventService.RemoveEvent(eEvent);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEventById(int id)
        {
            await _eventService.DeleteById(id);


        }

        [HttpPut]
        public async Task UpdateEvent(Event eEvent)
        {
            await _eventService.UpdateEvent(eEvent);
        }
    }
}
