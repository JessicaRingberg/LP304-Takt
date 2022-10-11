using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class EventStatusService : IEventStatusService
    {
        private readonly IEventStatusRepository _eventStatusRepository;

        public EventStatusService(IEventStatusRepository eventStatusRepository)
        {
            _eventStatusRepository = eventStatusRepository;
        }
        public async Task<ServiceResponse<int>> Add(EventStatus eventStatus)
        {
            return await _eventStatusRepository.Add(eventStatus);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            return await _eventStatusRepository.DeleteEntity(id);
        }

        public async Task<ICollection<EventStatus>> GetEntities()
        {
            return await _eventStatusRepository.GetEntities();
        }

        public async Task<EventStatus?> GetEntity(int id)
        {
            return await _eventStatusRepository.GetEntity(id);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(EventStatus eventStatus, int eventStatusId)
        {
            return await _eventStatusRepository.UpdateEntity(eventStatus, eventStatusId);
        }
    }
}
