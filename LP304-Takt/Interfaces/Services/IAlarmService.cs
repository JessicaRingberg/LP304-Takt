using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IAlarmService : IBaseService<Alarm>
    {
        Task Add(Alarm alarm, int orderId);
    }
}
