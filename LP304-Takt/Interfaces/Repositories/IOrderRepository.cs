using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task Add(Order order, int stationId);
        
    }
}
