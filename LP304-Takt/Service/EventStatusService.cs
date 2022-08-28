using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class EventStatusService : IEventStatusService
    {
        private readonly IUnitOfWork _eventStatusUnitOfWork;

        public EventStatusService(IUnitOfWork eventStatusUnitOfWork)
        {
            _eventStatusUnitOfWork = eventStatusUnitOfWork;
        }
        public async Task AddEventStatus(EventStatus eventStatus)
        {
            await _eventStatusUnitOfWork.EventStatus.Add(eventStatus);
        }

        public async Task<IEnumerable<EventStatus>> GetAllEventStatuses()
        {
            return await _eventStatusUnitOfWork.EventStatus.GetAll();
        }

        public async Task<EventStatus> GetOneEventStatus(int id)
        {
            return await _eventStatusUnitOfWork.EventStatus.GetById(id);
        }

        public async Task RemoveEventStatus(EventStatus eventStatus)
        {
            await _eventStatusUnitOfWork.EventStatus.Remove(eventStatus);
        }

        public async Task<EventStatus> UpdateEventStatus(EventStatus eventStatus)
        {
            return await _eventStatusUnitOfWork.EventStatus.Update(eventStatus);
        }
        public async Task DeleteById(int id)
        {
            var eventStatus = await _eventStatusUnitOfWork.EventStatus.GetById(id);
            await _eventStatusUnitOfWork.EventStatus.Remove(eventStatus);
            _eventStatusUnitOfWork.Complete();

        }
    }
}
