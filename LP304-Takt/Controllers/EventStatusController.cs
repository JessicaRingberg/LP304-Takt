using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
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

        [HttpGet("{id}")]
        public async Task<EventStatus> GetOneEventStatus(int id)
        {
            return await _eventStatusService.GetOneEventStatus(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _eventStatusService.GetAllEventStatuses();
        }

        [HttpPost]
        public async Task AddEventStatus(EventStatus eventStatus)
        {
            await _eventStatusService.AddEventStatus(eventStatus);
        }

        [HttpDelete]
        public async Task RemoveEventStatus(EventStatus eventStatus)
        {
            await _eventStatusService.RemoveEventStatus(eventStatus);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEventStatusById(int id)
        {
            await _eventStatusService.DeleteById(id);


        }

        [HttpPut]
        public async Task UpdateEventStatus(EventStatus eventStatus)
        {
            await _eventStatusService.UpdateEventStatus(eventStatus);
        }
    }
}
