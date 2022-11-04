using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IOrderDetailsService : IBaseService<OrderDetails>
    {
        Task<ServiceResponse<OrderDetails>> Add(OrderDetails orderDetails, int orderId, int articleId);
    }
}
