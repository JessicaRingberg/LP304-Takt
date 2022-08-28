using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _orderUnitOfWork;

        public OrderService(IUnitOfWork orderUnitOfWork)
        {
            _orderUnitOfWork = orderUnitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderUnitOfWork.Orders.GetAll();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _orderUnitOfWork.Orders.GetById(id);
        }
        public async Task AddOrder(Order order)
        {
            await _orderUnitOfWork.Orders.Add(order);
            _orderUnitOfWork.Complete();
        }

        public async Task RemoveOrder(Order order)
        {
            await _orderUnitOfWork.Orders.Remove(order);
            _orderUnitOfWork.Complete();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            await _orderUnitOfWork.Orders.Update(order);
            _orderUnitOfWork.Complete();
            return order;
        }
        public async Task DeleteById(int id)
        {
            var order = await _orderUnitOfWork.Orders.GetById(id);
            await _orderUnitOfWork.Orders.Remove(order);
            _orderUnitOfWork.Complete();

        }
    }
}
