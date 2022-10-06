using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IOrderDetailsService : IBaseService<OrderDetails>
    {
        Task Add(OrderDetails orderDetails, int orderId, int articleId);
    }
}
