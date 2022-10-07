using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetails>
    {
        Task Add(OrderDetails orderDetails, int orderId, int articleId);
    }
}
