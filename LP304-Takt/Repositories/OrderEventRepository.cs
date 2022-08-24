using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class OrderEventRepository : GenericRepository<OrderEvent>, IOrderEventRepository
    {
        public OrderEventRepository(LP304Context context) : base(context)
        {

        }
    }
}
