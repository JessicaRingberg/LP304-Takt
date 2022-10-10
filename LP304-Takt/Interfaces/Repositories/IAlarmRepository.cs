using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IAlarmRepository : IBaseRepository<Alarm>
    {
        Task<ServiceResponse<int>> Add(Alarm alarm, int orderId, int alarmTypeId);
        
    }
}
