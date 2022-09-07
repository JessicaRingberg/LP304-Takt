using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Add(Order order, int stationId)
        {
            await _orderRepository.Add(order, stationId);
        }

        public async Task DeleteEntity(int id)
        {
            await _orderRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Order>> GetEntities()
        {
            return await _orderRepository.GetEntities();
        }

        public async Task<Order?> GetEntity(int id)
        {
            return await _orderRepository.GetEntity(id);
        }

        public Task UpdateEntity(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
