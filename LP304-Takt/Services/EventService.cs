using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Add(Event eEvent, int orderId)
        {
            await _eventRepository.Add(eEvent, orderId);
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Event>> GetEntities()
        {
            return await _eventRepository.GetEntities();
        }

        public Task<Event?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
