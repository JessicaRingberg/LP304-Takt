﻿using LP304_Takt.Interfaces.Repositories;
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

        public async Task Add(Event eEvent, int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order is null)
            {
                return;
            }

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
                .ToListAsync();
        }

        public async Task<Event?> GetEntity(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task UpdateEntity(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}