using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task Add(OrderDetails orderDetails, int orderId, int articleId)
        {
            await _orderDetailsRepository.Add(orderDetails, orderId, articleId);
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<OrderDetails>> GetEntities()
        {
            return await _orderDetailsRepository.GetEntities(); ;
        }

        public Task<OrderDetails?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(OrderDetails entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
