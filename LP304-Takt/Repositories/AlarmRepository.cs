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
        public async Task Add(Alarm alarm, int orderId, int alarmTypeId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var alarmType = await _context.AlarmTypes.FindAsync(alarmTypeId);

            if (order is null)
            {
                return;
            }

            if (alarmType is null)
            {
                return;
            }

            alarm.AlarmTypeId = alarmTypeId;
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

        public async Task UpdateEntity(Alarm alarm, int alarmId)
        { 
            var alarmToUpdate = await _context.Alarms
                .FindAsync(alarmId);
            if (alarmToUpdate is null)
            {
                return;
            }

            MapAlarm(alarmToUpdate, alarm);

            await _context.SaveChangesAsync();
        }

        private static Alarm MapAlarm(Alarm newAlarm, Alarm oldAlarm)
        {
            newAlarm.Reason = oldAlarm.Reason;
            return newAlarm;
        }

    }
}
