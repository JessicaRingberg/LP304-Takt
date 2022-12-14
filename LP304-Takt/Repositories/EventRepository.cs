using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LP304_Takt.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Event>> Add(Event eEvent, int orderId, int eventStatusId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var eventStatus = await _context.EventStatuses.FindAsync(eventStatusId);
            if (order is null)
            {
                return new ServiceResponse<Event>()
                {
                    Success = false,
                    Message = $"No order with {orderId} was found!"
                };
            }

            else if (eventStatus is null)
            {
                return new ServiceResponse<Event>()
                {
                    Success = false,
                    Message = $"No eventstatus with id {eventStatusId} was found!"
                };
            }

            else
            eEvent.EventStatusId = eventStatusId;
            eEvent.OrderId = orderId;
            await _context.Events.AddAsync(eEvent);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Event>()
            {
                Data = eEvent,
                Success = true,
                Message = $"Event added"
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int eventId)
        {
            var eEvent = await _context.Events
                .FirstOrDefaultAsync(e => e.Id == eventId);
            if (eEvent is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Event with id: {eventId} was not found"
                };
            }
            _context.Events.Remove(eEvent);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Event with id {eventId} deleted"
            };
        }

        public async Task<ICollection<Event>> GetEntities()
        {
            return await _context.Events
                .Include(e => e.EventStatus)
                .ToListAsync();
        }

        public async Task<Event?> GetEntity(int eventId)
        {
            return await _context.Events
                .Include(e => e.EventStatus)
                .FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Event eEvent, int eventId)
        {
            var eventToUpdate = await _context.Events
                .FindAsync(eventId);
            if (eventToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = true,
                    Message = $"Event with id {eventId} was not found"
                };
            }

            eventToUpdate.Reason = eEvent.Reason;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Event with id {eventId} updated"
            };
        }
    }
}
