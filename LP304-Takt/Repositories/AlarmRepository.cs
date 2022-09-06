using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly DataContext _context;

        public AlarmRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Alarm alarm, int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order is null)
            {
                return;
            }

            alarm.OrderId = orderId;
            await _context.Alarms.AddAsync(alarm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var alarm = await _context.Alarms
                .FirstOrDefaultAsync(a => a.Id == id);
            if (alarm is null)
            {
                return;
            }
            _context.Alarms.Remove(alarm);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Alarm>> GetEntities()
        {
            return await _context.Alarms
                .ToListAsync();
        }

        public async Task<Alarm?> GetEntity(int id)
        {
            return await _context.Alarms
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task UpdateEntity(Alarm entity)
        {
            throw new NotImplementedException();
        }
    }
}
