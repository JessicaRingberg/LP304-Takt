using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(LP304Context context) : base(context)
        {

        }
    }
}
