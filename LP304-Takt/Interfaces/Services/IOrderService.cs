using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<ServiceResponse<int>> Add(Order order, int stationId);     
    }
}
