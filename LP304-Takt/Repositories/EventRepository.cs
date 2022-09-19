using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Event eEvent, int orderId, int eventStatusId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var eventStatus = await _context.EventStatuses.FindAsync(eventStatusId);

            if (order is null)
            {
                return;
            }

            if (eventStatus is null)
            {
                return;
            }

            eEvent.EventStatusId = eventStatusId;
            eEvent.OrderId = orderId;
            await _context.Events.AddAsync(eEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var eEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eEvent is null)
            {
                return;
            }
            _context.Events.Remove(eEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Event>> GetEntities()
        {
            return await _context.Events
                .Include(e => e.EventStatus)
                .ToListAsync();
        }

        public async Task<Event?> GetEntity(int id)
        {
            return await _context.Events
                .Include(e => e.EventStatus)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateEntity(Event eEvent, int eventId)
        {
            var eventToUpdate = await _context.Events
                .FindAsync(eventId);
            if (eventToUpdate is null)
            {
                return;
            }

            MapEvent(eventToUpdate, eEvent);

            await _context.SaveChangesAsync();
        }

        private static Event MapEvent(Event newEvent, Event oldEvent)
        {
            newEvent.Reason = oldEvent.Reason;
            return newEvent;
        }
    }
}
