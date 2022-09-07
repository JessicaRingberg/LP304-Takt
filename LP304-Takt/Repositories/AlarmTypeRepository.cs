using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class AlarmTypeRepository : IAlarmTypeRepository
    {
        private readonly DataContext _context;

        public AlarmTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(AlarmType alarmType)
        {
            await _context.AlarmTypes.AddAsync(alarmType);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var alarmType = await _context.AlarmTypes
                .FirstOrDefaultAsync(a => a.Id == id);
            if (alarmType is null)
            {
                return;
            }
            _context.AlarmTypes.Remove(alarmType);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AlarmType>> GetEntities()
        {
            return await _context.AlarmTypes
                .Include(a => a.Alarms)
                .ToListAsync();
        }

        public async Task<AlarmType?> GetEntity(int id)
        {
            return await _context.AlarmTypes
                .Include(a => a.Alarms)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task UpdateEntity(AlarmType entity)
        {
            throw new NotImplementedException();
        }
    }
}
