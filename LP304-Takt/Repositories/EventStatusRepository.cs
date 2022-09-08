using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class EventStatusRepository : IEventStatusRepository
    {
        private readonly DataContext _context;

        public EventStatusRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(EventStatus eventStatus)
        {
            await _context.EventStatuses.AddAsync(eventStatus);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var eventStatus = await _context.EventStatuses
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eventStatus is null)
            {
                return;
            }
            _context.EventStatuses.Remove(eventStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<EventStatus>> GetEntities()
        {
            return await _context.EventStatuses
                .Include(e => e.Events)
                .ToListAsync();
        }

        public async Task<EventStatus?> GetEntity(int id)
        {
            return await _context.EventStatuses
                .Include(e => e.Events)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateEventStatus(EventStatus eventStatus, int eventStatusId)
        {
            var eventStatusToUpdate = await _context.EventStatuses
                .FindAsync(eventStatusId);
            if (eventStatusToUpdate is null)
            {
                return;
            }

            MapEventStatus(eventStatusToUpdate, eventStatus);

            await _context.SaveChangesAsync();
        }

        private static EventStatus MapEventStatus(EventStatus newEventStatus, EventStatus oldEventStatus)
        {
            newEventStatus.Name = oldEventStatus.Name;
            return newEventStatus;
        }
    }
}
