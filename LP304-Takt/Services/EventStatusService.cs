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
        public async Task<ServiceResponse<EventStatus>> Add(EventStatus eventStatus)
        {
            return await _eventStatusRepository.Add(eventStatus);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int eventStatusId)
        {
            return await _eventStatusRepository.DeleteEntity(eventStatusId);
        }

        public async Task<ICollection<EventStatus>> GetEntities()
        {
            return await _eventStatusRepository.GetEntities();
        }

        public async Task<EventStatus?> GetEntity(int eventStatusId)
        {
            return await _eventStatusRepository.GetEntity(eventStatusId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(EventStatus eventStatus, int eventStatusId)
        {
            return await _eventStatusRepository.UpdateEntity(eventStatus, eventStatusId);
        }
    }
}
