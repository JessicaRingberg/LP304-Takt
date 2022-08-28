using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class OrderEventService : IOrderEventService
    {
        private readonly IUnitOfWork _orderEventUnitOfWork;

        public OrderEventService(IUnitOfWork orderEventUnitOfWork)
        {
            _orderEventUnitOfWork = orderEventUnitOfWork;
        }
        public async Task AddOrderEvent(OrderEvent orderEvent)
        {
            await _orderEventUnitOfWork.OrderEvents.Add(orderEvent);
        }

        public async Task<IEnumerable<OrderEvent>> GetAllOrderEvents()
        {
            return await _orderEventUnitOfWork.OrderEvents.GetAll();
        }

        public async Task<OrderEvent> GetOrderEvent(int id)
        {
            return await _orderEventUnitOfWork.OrderEvents.GetById(id);
        }

        public async Task RemoveOrderEvent(OrderEvent orderEvent)
        {
            await _orderEventUnitOfWork.OrderEvents.Remove(orderEvent);
        }

        public async Task<OrderEvent> UpdateOrderEvent(OrderEvent orderEvent)
        {
            return await _orderEventUnitOfWork.OrderEvents.Update(orderEvent);
        }
        public async Task DeleteById(int id)
        {
            var orderEvent = await _orderEventUnitOfWork.OrderEvents.GetById(id);
            await _orderEventUnitOfWork.OrderEvents.Remove(orderEvent);
            _orderEventUnitOfWork.Complete();

        }
    }
}
