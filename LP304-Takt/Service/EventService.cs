using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _eventUnitOfWork;

        public EventService(IUnitOfWork eventUnitOfWork)
        {
            _eventUnitOfWork = eventUnitOfWork;
        }
        public async Task AddEvent(Event eEvent)
        {
            await _eventUnitOfWork.Events.Add(eEvent);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventUnitOfWork.Events.GetAll();
        }

        public async Task<Event> GetOneEvent(int id)
        { 
            return await _eventUnitOfWork.Events.GetById(id);
        }

        public async Task RemoveEvent(Event eEvent)
        {
            await _eventUnitOfWork.Events.Remove(eEvent);
        }

        public async Task<Event> UpdateEvent(Event eEvent)
        {
            return await _eventUnitOfWork.Events.Update(eEvent);
        }
        public async Task DeleteById(int id)
        {
            var eEvent = await _eventUnitOfWork.Events.GetById(id);
            await _eventUnitOfWork.Events.Remove(eEvent);
            _eventUnitOfWork.Complete();

        }
    }
}
