using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class EventStatusService : IEventStatusService
    {
        private readonly IEventStatusRepository _eventStatusRepository;

        public EventStatusService(IEventStatusRepository eventStatusRepository)
        {
            _eventStatusRepository = eventStatusRepository;
        }
        public async Task Add(EventStatus eventStatus)
        {
            await _eventStatusRepository.Add(eventStatus);
        }

        public async Task DeleteEntity(int id)
        {
            await _eventStatusRepository.DeleteEntity(id);
        }

        public async Task<ICollection<EventStatus>> GetEntities()
        {
            return await _eventStatusRepository.GetEntities();
        }

        public async Task<EventStatus?> GetEntity(int id)
        {
            return await _eventStatusRepository.GetEntity(id);
        }

        public Task UpdateEntity(EventStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
