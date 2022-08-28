using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;
using NuGet.Protocol;

namespace LP304_Takt.Service
{
    public class AlarmTypeService : IAlarmTypeService
    {
        private readonly IUnitOfWork _alarmTypeUnitOfWork;

        public AlarmTypeService(IUnitOfWork alarmTypeUnitOfWork)
        {
            _alarmTypeUnitOfWork = alarmTypeUnitOfWork;
        }
        public async Task AddAlarmType(AlarmType alarmType)
        {
            await _alarmTypeUnitOfWork.AlarmTypes.Add(alarmType);
        }

        public async Task<IEnumerable<AlarmType>> GetAllAlarmTypes()
        {
            return await _alarmTypeUnitOfWork.AlarmTypes.GetAll();
        }

        public async Task<AlarmType> GetOneAlarmType(int id)
        {
            return await _alarmTypeUnitOfWork.AlarmTypes.GetById(id);
        }

        public async Task RemoveAlarmType(AlarmType alarmType)
        {
            await _alarmTypeUnitOfWork.AlarmTypes.Remove(alarmType);
        }

        public async Task<AlarmType> UpdateAlarmType(AlarmType alarmType)
        {
            return await _alarmTypeUnitOfWork.AlarmTypes.Update(alarmType);
        }
        public async Task DeleteById(int id)
        {
            var alarmType = await _alarmTypeUnitOfWork.AlarmTypes.GetById(id);
            await _alarmTypeUnitOfWork.AlarmTypes.Remove(alarmType);
            _alarmTypeUnitOfWork.Complete();

        }
    }
}
