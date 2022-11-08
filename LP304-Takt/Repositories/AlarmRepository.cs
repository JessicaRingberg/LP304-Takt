using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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
        public async Task<ServiceResponse<Alarm>> Add(Alarm alarm, int orderId, int alarmTypeId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var alarmType = await _context.AlarmTypes.FindAsync(alarmTypeId);
            if (order is null)
            {
                return new ServiceResponse<Alarm>()
                {
                    Success = false,
                    Message = $"Alarm must belong to an order!"
                };
            }

            else if (alarmType is null)
            {
                return new ServiceResponse<Alarm>()
                {
                    Success = false,
                    Message = $"Alarm must have a type!"
                };
            }
            else
            alarm.AlarmTypeId = alarmTypeId;
            alarm.OrderId = orderId;
            await _context.Alarms.AddAsync(alarm);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Alarm>()
            {
                Data = alarm,
                Success = true,
                Message = "Alarm added"
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int alarmId)
        {
            var alarm = await _context.Alarms
                .FirstOrDefaultAsync(a => a.Id == alarmId);
            if (alarm is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Alarm with id {alarmId} was not found"
                };
            }

            _context.Alarms.Remove(alarm);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Alarm with id {alarm.Id} deleted"
            };
        }

        public async Task<ICollection<Alarm>> GetEntities()
        {
            return await _context.Alarms
                .Include(a => a.AlarmType)
                .ToListAsync();
        }

        public async Task<Alarm?> GetEntity(int alarmId)
        {
            return await _context.Alarms
                .Include(a => a.AlarmType)
                .FirstOrDefaultAsync(e => e.Id == alarmId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Alarm alarm, int alarmId)
        { 
            var alarmToUpdate = await _context.Alarms
                .FindAsync(alarmId);
            if (alarmToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Alarm with id {alarmId} was not found"
                };
            }

            alarmToUpdate.Reason = alarm.Reason;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Alarm with id {alarm.Id} updated"
            };
        }

    }
}
