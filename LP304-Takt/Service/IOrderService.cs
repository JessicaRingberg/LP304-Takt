using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IOrderService
    {
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task AddOrder(Order order);
        Task RemoveOrder(Order order);
        Task<Order> UpdateOrder(Order order);
    }
}
