using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class OrderAlarmService : IOrderAlarmService
    {
        private readonly IUnitOfWork _orderAlarmUnitOfWork;

        public OrderAlarmService(IUnitOfWork orderAlarmUnitOfWork)
        {
            _orderAlarmUnitOfWork = orderAlarmUnitOfWork;
        }
        public async Task AddOrderAlarm(OrderAlarm orderAlarm)
        {
            await _orderAlarmUnitOfWork.OrderAlarms.Add(orderAlarm);
        }

        public async Task<IEnumerable<OrderAlarm>> GetAllOrderAlarms()
        {
            return await _orderAlarmUnitOfWork.OrderAlarms.GetAll();
        }

        public async Task<OrderAlarm> GetOrderAlarm(int id)
        {
            return await _orderAlarmUnitOfWork.OrderAlarms.GetById(id);
        }

        public async Task RemoveOrderAlarm(OrderAlarm orderAlarm)
        {
            await _orderAlarmUnitOfWork.OrderAlarms.Remove(orderAlarm);
        }

        public async Task<OrderAlarm> UpdateOrderAlarm(OrderAlarm orderAlarm)
        {
            return await _orderAlarmUnitOfWork.OrderAlarms.Update(orderAlarm);
        }
    }
}
