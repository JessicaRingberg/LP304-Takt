using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task Add(Order order, int stationId);
     
    }
}
