using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(LP304Context context) : base(context)
        {

        }
    }
}
