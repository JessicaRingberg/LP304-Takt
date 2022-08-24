using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class AlarmTypeRepository : GenericRepository<AlarmType>, IAlarmTypeRepository
    {
        public AlarmTypeRepository(LP304Context context) : base(context)
        {

        }
    }
}
