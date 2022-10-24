using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<ServiceResponse<int>> Add(OrderDetails orderDetails, int orderId, int articleId)
        {
            return await _orderDetailsRepository.Add(orderDetails, orderId, articleId);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            return await _orderDetailsRepository.DeleteEntity(id);
        }

        public async Task<ICollection<OrderDetails>> GetEntities()
        {
            return await _orderDetailsRepository.GetEntities(); ;
        }

        public async Task<OrderDetails?> GetEntity(int id)
        {
            return await _orderDetailsRepository.GetEntity(id);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(OrderDetails orderDetails, int orderDetailsId)
        {
            return await _orderDetailsRepository.UpdateEntity(orderDetails, orderDetailsId);
        }
    }
}
