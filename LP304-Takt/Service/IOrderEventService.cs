using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IOrderEventService
    {
        Task<IEnumerable<OrderEvent>> GetAllOrderEvents();
        Task<OrderEvent> GetOrderEvent(int id);
        Task AddOrderEvent(OrderEvent orderEvent);
        Task RemoveOrderEvent(OrderEvent orderEvent);
        Task<OrderEvent> UpdateOrderEvent(OrderEvent orderEvent);
        Task DeleteById(int id);
    }
}
