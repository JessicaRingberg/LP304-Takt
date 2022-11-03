using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<ServiceResponse<int>> Add(Order order, int stationId);
        Task<ICollection<Order>> GetOrdersByArea(int areaId);
    }
}
