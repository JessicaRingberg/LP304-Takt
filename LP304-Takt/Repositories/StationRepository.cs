using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(LP304Context context) : base(context)
        {

        }
    }
}
