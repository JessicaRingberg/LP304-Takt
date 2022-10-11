using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LP304_Takt.Repositories
{
    public class AlarmTypeRepository : IAlarmTypeRepository
    {
        private readonly DataContext _context;

        public AlarmTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Add(AlarmType alarmType)
        {
            var found = await _context.AlarmTypes.FirstOrDefaultAsync(c => c.Name == alarmType.Name);
            if (found is not null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"AlarmType with name {alarmType.Name} already exists!"
                };
            }
            await _context.AlarmTypes.AddAsync(alarmType);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int> { Data = alarmType.Id, Success = true, Message = $"AlarmType named {alarmType.Name} added." };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var alarmType = await _context.AlarmTypes
                .FirstOrDefaultAsync(a => a.Id == id);
            if (alarmType is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"AlarmType with id: {id} was not found"
                };
            }
            _context.AlarmTypes.Remove(alarmType);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"AlarmType {alarmType.Name} deleted"
            };
        }

        public async Task<ICollection<AlarmType>> GetEntities()
        {
            return await _context.AlarmTypes
                .ToListAsync();
        }

        public async Task<AlarmType?> GetEntity(int id)
        {
            return await _context.AlarmTypes
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(AlarmType alarmType, int alarmTypeId)
        {
            var alarmTypeToUpdate = await _context.AlarmTypes
                .FindAsync(alarmTypeId);
            if (alarmTypeToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"AlarmType with id {alarmTypeId} was not found"
                };
            }

            MapAlarmType(alarmTypeToUpdate, alarmType);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"AlarmType {alarmType.Name} updated"
            };
        }

        private static AlarmType MapAlarmType(AlarmType newAlarmType, AlarmType oldAlarmType)
        {
            newAlarmType.Name = oldAlarmType.Name;
            return newAlarmType;
        }
    }
}
