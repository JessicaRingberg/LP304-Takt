using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class AlarmRepository : GenericRepository<Alarm>, IAlarmRepository
    {
        public AlarmRepository(LP304Context context) : base(context)
        {

        }
    }
}
