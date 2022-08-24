using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class OrderAlarmRepository : GenericRepository<OrderAlarm>, IOrderAlarmRepository
    {
        public OrderAlarmRepository(LP304Context context) : base(context)
        {

        }
    }
}
