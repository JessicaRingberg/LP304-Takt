using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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
        public async Task<ServiceResponse<int>> Add(EventStatus eventStatus)
        {
            var found = _context.EventStatuses.FirstOrDefaultAsync(e => e.Name == eventStatus.Name);
            if(found is not null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"EventStatus already exists!"
                };
            }
            await _context.EventStatuses.AddAsync(eventStatus);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"EventStatus added"
            };

        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var eventStatus = await _context.EventStatuses
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eventStatus is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Eventstatus with id: {id} was not found"
                };
            }
            _context.EventStatuses.Remove(eventStatus);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Eventstatus with id: {id} deleted"
            };
        }

        public async Task<ICollection<EventStatus>> GetEntities()
        {
            return await _context.EventStatuses
                .ToListAsync();
        }

        public async Task<EventStatus?> GetEntity(int id)
        {
            return await _context.EventStatuses
                .Include(e => e.Events)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(EventStatus eventStatus, int eventStatusId)
        {
            var eventStatusToUpdate = await _context.EventStatuses
                .FindAsync(eventStatusId);
            if (eventStatusToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Eventstatus with id: {eventStatusId} was not found"
                };
            }

            eventStatusToUpdate.Name = eventStatus.Name;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Eventstatus with id: {eventStatusId} updated"
            };
        }
    }
}
