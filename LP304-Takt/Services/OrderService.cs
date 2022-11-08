using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResponse<Order>> Add(Order order, int stationId)
        {
           return await _orderRepository.Add(order, stationId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int orderId)
        {
            return await _orderRepository.DeleteEntity(orderId);
        }

        public async Task<ICollection<Order>> GetEntities()
        {
            return await _orderRepository.GetEntities();
        }

        public async Task<Order?> GetEntity(int orderId)
        {
            return await _orderRepository.GetEntity(orderId);
        }

        public async Task<ICollection<Order>> GetOrdersByArea(int areaId)
        {
            return await _orderRepository.GetOrdersByArea(areaId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Order order, int orderId)
        {
            return await _orderRepository.UpdateEntity(order, orderId);
        }
    }
}
