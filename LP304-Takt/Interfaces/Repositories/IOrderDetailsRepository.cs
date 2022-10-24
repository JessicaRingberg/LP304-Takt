using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IOrderDetailsRepository : IBaseRepository<OrderDetails>
    {
        Task<ServiceResponse<int>> Add(OrderDetails orderDetails, int orderId, int articleId);
    }
}
