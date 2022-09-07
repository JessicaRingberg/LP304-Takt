﻿using LP304_Takt.Interfaces.Repositories;
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

        public Task UpdateEntity(EventStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}