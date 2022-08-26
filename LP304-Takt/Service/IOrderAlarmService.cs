using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IOrderAlarmService
    {
        Task<IEnumerable<OrderAlarm>> GetAllOrderAlarms();
        Task<OrderAlarm> GetOrderAlarm(int id);
        Task AddOrderAlarm(OrderAlarm orderAlarm);
        Task RemoveOrderAlarm(OrderAlarm orderAlarm);
        Task<OrderAlarm> UpdateOrderAlarm(OrderAlarm orderAlarm);
    }
}
